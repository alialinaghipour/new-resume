namespace Framework.Contracts.Identities.Core.Entities;

public class ApplicationUserVerificationCode
{
    public long Id { get; set; }
    public string VerificationCode { get; set; }
    public DateTime VerificationDate { get; set; }
    public string SmsResultDesc { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsVerified { get; set; }
}