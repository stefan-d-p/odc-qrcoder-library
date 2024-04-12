using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.QrCode
{
    [OSInterface(
        Name = "QRCoder",
        Description = "Generates a QR code",
        IconResourceName = "Without.Systems.QrCode.Resources.QRCoder.png")]
    public interface IQrCode
    {
        [OSAction(
            Description = "Generate a QR Code as PNG image file",
            IconResourceName = "Without.Systems.QrCode.Resources.QRCoder.png",
            ReturnName = "result",
            ReturnType = OSDataType.BinaryData,
            ReturnDescription = "QR Code PNG image file")]
        byte[] GeneratePngCode(
            [OSParameter(
                Description =
                    "QR code payload. Can be any arbitrary text or a structured QR code format. Use the QRCoder Payload library to generate specific QR code payloads e.g. for connecting to a WiFi network.",
                DataType = OSDataType.Text)]
            string payload,
            [OSParameter(
                Description = "Color as HEX code for dark patterns. Defaults to #000000",
                DataType = OSDataType.Text)]
            string darkColor = "#000000",
            [OSParameter(
                Description = "Color as HEX code for light patterns. Defaults to #FFFFFF",
                DataType = OSDataType.Text)]
            string lightColor = "#FFFFFF",
            [OSParameter(
                Description =
                    "Error correction level. Can have one of the following values: L - 7% may be lost before recovery is not possible, M - 15% may be lost before recovery is possible, Q - 25% may be lost before recovery, H - 30% may be lost before recovery. Defaults to M",
                DataType = OSDataType.Text)]
            string eccLevel = "M",
            [OSParameter(
                Description = "Pixels per module. The pixel size each b/w module is drawn. Defaults to 20",
                DataType = OSDataType.Integer)] int pixelsPerModule = 20,
            [OSParameter(
                Description = "Draw Quite Zones. Defaults to true")] bool drawQuietZones = true
        );
    }
}