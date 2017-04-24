using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using ZXing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace QREncoderGUI
{
    public partial class MainForm : Form
    {
        private const BarcodeFormat DEFAULT_BARCODE_FORMAT = BarcodeFormat.QR_CODE;
        private static readonly ImageFormat DEFAULT_IMAGE_FORMAT = ImageFormat.Png;
        private const string DEFAULT_OUTPUT_DIRECTORY = @"QRCodes.out\";
        private const int DEFAULT_WIDTH = 600;
        private const int DEFAULT_HEIGHT = 600;
        private const string DEFAULT_SELECT_LOGO_HINT = "Select LOGO File (Optional)";

        private Bitmap logo;
        private bool isBackgroundColorWhite = true;

        private object thisLock = new object();

        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "All Image Files|*.jpeg;*.jpg;*.png;|" +
                                    "JPEG (*.jpg)|*.jpg;*.jpeg|" +
                                    "PNG (*.png)|*.png"
            };
            if (DialogResult.OK == openFileDialog.ShowDialog(this))
            {
                var img = Image.FromFile(openFileDialog.FileName);
                if (img != null)
                {
                    radioButtonColorWhite.Enabled = true;
                    radioButtonColorBlack.Enabled = true;
                    logo = new Bitmap(img);
                    textBoxFileName.Text = openFileDialog.SafeFileName;
                }
            }
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                var dataColumnKey = new DataColumn("key", typeof(int));
                var dataColumnValue = new DataColumn("value", typeof(string));
                dataTable.Columns.Add(dataColumnKey);
                dataTable.Columns.Add(dataColumnValue);
                //TODO: add your data here

                labelHint.Text = "";

                Directory.CreateDirectory(DEFAULT_OUTPUT_DIRECTORY);

                int n = dataTable.Rows.Count;
                int stride = 50;
                for (int i = 0; i < n; i += stride)
                {
                    Parallel.For(i, Math.Min(i + stride, n), j =>
                    {
                        GenerateQRCode(dataTable.Rows[j]);
                    });
                }
                System.Diagnostics.Process.Start("explorer", DEFAULT_OUTPUT_DIRECTORY);
            }
            catch (Exception)
            {
                labelHint.Text = "Not Found";
            }
        }

        private void GenerateQRCode(DataRow dataRows)
        {
            var barcodeFormat = DEFAULT_BARCODE_FORMAT;
            var imageFormat = DEFAULT_IMAGE_FORMAT;
            var outFileString = DEFAULT_OUTPUT_DIRECTORY + dataRows["key"].ToString();
            var width = DEFAULT_WIDTH;
            var height = DEFAULT_HEIGHT;

            outFileString += '.' + imageFormat.ToString();

            //TODO: change your qrcode content here
            string contents = "key:" + dataRows["key"].ToString() + " value:" + dataRows["value"].ToString();

            var barcodeWriter = new BarcodeWriter
            {
                Format = barcodeFormat,
                Options = new QrCodeEncodingOptions
                {
                    ErrorCorrection = ErrorCorrectionLevel.M,
                    Height = height,
                    Width = width
                }
            };

            var bitmap = barcodeWriter.Write(contents);

            if (logo != null)
            {
                int backgroundWidth = 10;
                int backgroundHeight = 10;
                lock (thisLock)
                {
                    backgroundWidth += logo.Width;
                    backgroundHeight += logo.Height;
                }

                var background = new Bitmap(backgroundWidth, backgroundHeight);
                var graphics = Graphics.FromImage(background);
                if (isBackgroundColorWhite)
                {
                    FillRoundRectangle(graphics, Brushes.White, new Rectangle(0, 0, backgroundWidth, backgroundHeight), 10);
                }
                else
                {
                    FillRoundRectangle(graphics, Brushes.Black, new Rectangle(0, 0, backgroundWidth, backgroundHeight), 10);
                }
                graphics.Dispose();
                lock (thisLock)
                {
                    bitmap = OverlayImage(background, bitmap);
                    bitmap = OverlayImage(logo, bitmap);
                }
            }

            bitmap.Save(outFileString, imageFormat);
            bitmap.Dispose();
        }

        private static Bitmap OverlayImage(Bitmap foregroundImage, Bitmap backgroundImage)
        {
            var newBitmap = new Bitmap(backgroundImage.Width, backgroundImage.Height);
            var graphics = Graphics.FromImage(newBitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = CompositingQuality.HighQuality;

            graphics.DrawImage(backgroundImage, 0, 0);
            graphics.DrawImage(foregroundImage, (backgroundImage.Width - foregroundImage.Width) / 2, (backgroundImage.Height - foregroundImage.Height) / 2);
            graphics.Dispose();

            return newBitmap;
        }

        public static void FillRoundRectangle(Graphics g, Brush brush, Rectangle rect, int cornerRadius)
        {
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.FillPath(brush, path);
            }
        }

        internal static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            var roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }

        private void RadioButtonColorWhite_CheckedChanged(object sender, EventArgs e)
        {
            isBackgroundColorWhite = true;
        }

        private void RadioButtonColorBlack_CheckedChanged(object sender, EventArgs e)
        {
            isBackgroundColorWhite = false;
        }

        internal void InitializeComboBox()
        {
            try
            {
                var dataTable = new DataTable();
                var dataColumnKey = new DataColumn("listValue", typeof(Int64));
                var dataColumnValue = new DataColumn("listName", typeof(String));
                dataTable.Columns.Add(dataColumnKey);
                dataTable.Columns.Add(dataColumnValue);

                //TODO: add value and name of combo here

                comboBoxTable.ValueMember = "listValue";
                comboBoxTable.DisplayMember = "listName";
                comboBoxTable.DataSource = dataTable;

                buttonGenerate.Enabled = true;
                buttonLoad.Enabled = true;
                labelHint.Text = "";
            }
            catch (Exception)
            {
                buttonGenerate.Enabled = false;
                buttonLoad.Enabled = false;
                labelHint.Text = "Error Initializing";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            radioButtonColorWhite.Enabled = false;
            radioButtonColorBlack.Enabled = false;

            InitializeComboBox();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            InitializeComboBox();
            if (logo != null)
            {
                logo.Dispose();
                logo = null;
                if (!isBackgroundColorWhite)
                {
                    radioButtonColorWhite.Select();
                    isBackgroundColorWhite = true;
                }
                radioButtonColorWhite.Enabled = false;
                radioButtonColorBlack.Enabled = false;
                textBoxFileName.Text = DEFAULT_SELECT_LOGO_HINT;
            }
        }

        private void ComboBoxTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTable.Items.Count > 0)
            {
                //TODO: handle option here
            }
        }
    }
}
