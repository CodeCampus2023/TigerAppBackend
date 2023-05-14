namespace TigerParkBackend.Application.AppData.Contexts.Sms;

public interface ISmsService
{
    Task SendSms(string text, CancellationToken cancellationToken);
}