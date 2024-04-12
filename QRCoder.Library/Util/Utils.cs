using System.Globalization;

namespace Without.Systems.QrCode.Util;

public static class Converter
{
    public static byte[] HexToRgba(string hex)
    {
        string clearedHex = hex.Replace("#", "");
        byte r = byte.Parse(clearedHex.Substring(0, 2), NumberStyles.HexNumber);
        byte g = byte.Parse(clearedHex.Substring(2, 2), NumberStyles.HexNumber);
        byte b = byte.Parse(clearedHex.Substring(4, 2), NumberStyles.HexNumber);
        const byte a = 255; // TODO: Check later if it makes sense to have the alpha as an additional parameter
        
        return new byte[] { r, g, b, a };

    }
}