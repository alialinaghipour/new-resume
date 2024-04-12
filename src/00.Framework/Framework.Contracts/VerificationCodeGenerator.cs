namespace Framework.Contracts;

public static class VerificationCodeGenerator
{
    public static string GenerateCode(
        int minValue = 10000,
        int maxValue = 99999)
    {
        var random = new Random();
        var verificationCode = (uint)random.Next(minValue,maxValue);
        return verificationCode.ToString();
    }
}