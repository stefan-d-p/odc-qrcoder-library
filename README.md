# OutSystems Developer Cloud QrCoder External Logic Library

QrCoder is based on the .net library by [Raffael Herrmann](https://github.com/codebude) and allows to generate QR Codes as PNG image files.

*If you have used my QrCoder Forge component for OutSystems 11 you will notice that there is no support for SVG, PDF and ArtQR anymore.
This is because for this features QrCoder depends on System.Drawing which is not available in .net 6.
Although there is a very good fork for QrCoder qrcode-imagesharp that implements SixLabs ImageSharp library as a replacement
for System.Drawing I decided to not use it because of the split license of imagesharp.*

This external logic library currently features a single action **GeneratePngCode** with the following input parameters

* `payload` - The payload of the QR code. This can be any arbitrary text, or a specified format like a VCard or a WiFi connection. To create specific payloads you can download and use the QRCoder Payload library from the forge.
* `eccLevel` - Error correction level. Can have one of the following values: L - 7% may be lost before recovery is not possible, M - 15% may be lost before recovery is possible, Q - 25% may be lost before recovery, H - 30% may be lost before recovery. Defaults to M.
* `pixelsPerModule` - Pixels per module. The pixel size each b/w module is drawn. Defaults to 20.
* `drawQuietZone` - Draw Quite Zones. Defaults to true.

returns

* `result` - The QR code PNG image as binary data.