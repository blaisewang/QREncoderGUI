# QREncoderGUI
QRCode encoder with GUI based on [ZXing.NET](http://zxingnet.codeplex.com/)


## Preview

![](https://camo.githubusercontent.com/9f53e93d3707ad91faabac631021bbe9f1cfa526/687474703a2f2f7778332e73696e61696d672e636e2f6c617267652f39636265343239666c7931666573653065316b6a646a323070753064676162612e6a7067) 


## Usage

You need to add [ZXing.NET](http://zxingnet.codeplex.com/) reference in Visual Studio before running `QREncoderGUI`.


## Performance 

According to my test, it takes 80 seconds for a single thread to generate 1000 QRCode images, but under the same conditions `QREncoderGUI` takes only about 16 seconds.
