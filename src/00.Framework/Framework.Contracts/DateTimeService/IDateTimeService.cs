namespace Framework.Contracts.DateTimeService;

public interface IDateTimeService
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}