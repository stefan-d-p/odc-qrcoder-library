namespace Without.Systems.QrCode.Test;

public class Tests
{
    private static readonly IQrCode _actions = new QrCode();

    [SetUp]
    public void Setup()
    {
    }

    [Test(
        Description = "Test QR Code with a simple URL")]
    public void Can_Generate_URL_QrCode()
    {
        byte[] expectedResult = File.ReadAllBytes(@"Codes\URL.png");
        byte[] result = _actions.GeneratePngCode("https://without.systems");

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}