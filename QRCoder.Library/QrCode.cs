using Microsoft.VisualBasic.CompilerServices;
using OutSystems.ExternalLibraries.SDK;
using QRCoder;
using Without.Systems.QrCode.Util;

namespace Without.Systems.QrCode;

public class QrCode : IQrCode
{
    /// <summary>
    /// Generates a QR code as PNG image.
    /// </summary>
    /// <param name="payload">QR code payload. Can be any arbitrary text or a structured QR code format. Use the QRCoder Payload library to generate specific QR code payloads e.g. for connecting to a WiFi network.</param>
    /// <param name="darkColor">Color as HEX code for dark patterns. Defaults to #000000</param>
    /// <param name="lightColor">Color as HEX code for light patterns. Defaults to #FFFFFF</param>
    /// <param name="eccLevel">Error correction level. Can have one of the following values: L - 7% may be lost before recovery is not possible, M - 15% may be lost before recovery is possible, Q - 25% may be lost before recovery, H - 30% may be lost before recovery. Defaults to M</param>
    /// <param name="pixelsPerModule">Pixels per module. The pixel size each b/w module is drawn. Defaults to 20</param>
    /// <param name="drawQuietZones">Draw Quite Zones. Defaults to true</param>
    /// <returns>PNG image as byte array</returns>
    public byte[] GeneratePngCode(string payload, string darkColor = "#000000", string lightColor = "#FFFFFF", string eccLevel = "M", int pixelsPerModule = 20, bool drawQuietZones = true)
    {
        QRCodeGenerator.ECCLevel errorCorrectionLevel;
        if(!Enum.TryParse<QRCodeGenerator.ECCLevel>(eccLevel, out errorCorrectionLevel))
        {
            errorCorrectionLevel = QRCodeGenerator.ECCLevel.M;
        }

        using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
        using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, errorCorrectionLevel))
        using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
        {
            return qrCode.GetGraphic(pixelsPerModule, Converter.HexToRgba(darkColor), Converter.HexToRgba(lightColor),drawQuietZones);
        }
    }
    
}