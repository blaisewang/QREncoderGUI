using System.Windows.Forms;

namespace QREncoderGUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.radioButtonColorWhite = new System.Windows.Forms.RadioButton();
            this.radioButtonColorBlack = new System.Windows.Forms.RadioButton();
            this.groupBoxColor = new System.Windows.Forms.GroupBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.comboBoxTable = new System.Windows.Forms.ComboBox();
            this.labelHint = new System.Windows.Forms.Label();
            this.groupBoxColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLoad.Location = new System.Drawing.Point(323, 12);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(90, 30);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(323, 130);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(90, 30);
            this.buttonGenerate.TabIndex = 1;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxFileName.Location = new System.Drawing.Point(15, 15);
            this.textBoxFileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.ReadOnly = true;
            this.textBoxFileName.Size = new System.Drawing.Size(300, 23);
            this.textBoxFileName.TabIndex = 2;
            this.textBoxFileName.Text = "Select LOGO File (Optional)";
            // 
            // radioButtonColorWhite
            // 
            this.radioButtonColorWhite.AutoSize = true;
            this.radioButtonColorWhite.Checked = true;
            this.radioButtonColorWhite.Location = new System.Drawing.Point(10, 25);
            this.radioButtonColorWhite.Name = "radioButtonColorWhite";
            this.radioButtonColorWhite.Size = new System.Drawing.Size(59, 21);
            this.radioButtonColorWhite.TabIndex = 4;
            this.radioButtonColorWhite.TabStop = true;
            this.radioButtonColorWhite.Text = "White";
            this.radioButtonColorWhite.UseVisualStyleBackColor = true;
            this.radioButtonColorWhite.CheckedChanged += new System.EventHandler(this.RadioButtonColorWhite_CheckedChanged);
            // 
            // radioButtonColorBlack
            // 
            this.radioButtonColorBlack.AutoSize = true;
            this.radioButtonColorBlack.Location = new System.Drawing.Point(108, 25);
            this.radioButtonColorBlack.Name = "radioButtonColorBlack";
            this.radioButtonColorBlack.Size = new System.Drawing.Size(57, 21);
            this.radioButtonColorBlack.TabIndex = 5;
            this.radioButtonColorBlack.TabStop = true;
            this.radioButtonColorBlack.Text = "Black";
            this.radioButtonColorBlack.UseVisualStyleBackColor = true;
            this.radioButtonColorBlack.CheckedChanged += new System.EventHandler(this.RadioButtonColorBlack_CheckedChanged);
            // 
            // groupBoxColor
            // 
            this.groupBoxColor.Controls.Add(this.radioButtonColorBlack);
            this.groupBoxColor.Controls.Add(this.radioButtonColorWhite);
            this.groupBoxColor.Location = new System.Drawing.Point(15, 110);
            this.groupBoxColor.Name = "groupBoxColor";
            this.groupBoxColor.Size = new System.Drawing.Size(170, 55);
            this.groupBoxColor.TabIndex = 6;
            this.groupBoxColor.TabStop = false;
            this.groupBoxColor.Text = "Background Color";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(208, 130);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(90, 30);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // comboBoxTable
            // 
            this.comboBoxTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTable.FormattingEnabled = true;
            this.comboBoxTable.Location = new System.Drawing.Point(15, 65);
            this.comboBoxTable.Name = "comboBoxTable";
            this.comboBoxTable.Size = new System.Drawing.Size(300, 25);
            this.comboBoxTable.TabIndex = 10;
            this.comboBoxTable.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTableName_SelectedIndexChanged);
            // 
            // labelHint
            // 
            this.labelHint.AutoSize = true;
            this.labelHint.ForeColor = System.Drawing.Color.Red;
            this.labelHint.Location = new System.Drawing.Point(322, 70);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(0, 17);
            this.labelHint.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 176);
            this.Controls.Add(this.labelHint);
            this.Controls.Add(this.comboBoxTable);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.groupBoxColor);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.buttonLoad);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "QREncoder";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxColor.ResumeLayout(false);
            this.groupBoxColor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonLoad;
        private Button buttonGenerate;
        private TextBox textBoxFileName;
        private RadioButton radioButtonColorWhite;
        private RadioButton radioButtonColorBlack;
        private GroupBox groupBoxColor;
        private Button buttonReset;
        private ComboBox comboBoxTable;
        private Label labelHint;
    }
}

