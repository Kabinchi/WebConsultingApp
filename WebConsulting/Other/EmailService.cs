using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public interface IEmailService
{
    Task<bool> SendConfirmationCodeAsync(string email, string code);
}

public class EmailService : IEmailService
{
    private readonly string _smtpServer = "smtp.mail.ru";
    private readonly int _smtpPort = 587;  
    private readonly string _smtpUser = "danya.kabanchik@mail.ru";
    private readonly string _smtpPassword = "GiDr0ta3uRZAVHNDKSGD";

    public async Task<bool> SendConfirmationCodeAsync(string email, string code)
    {
        try
        {
            var message = new MailMessage(_smtpUser, email, "Код подтверждения", $"Ваш код: {code}");
            using (var smtpClient = new SmtpClient(_smtpServer))
            {
                smtpClient.Credentials = new NetworkCredential(_smtpUser, _smtpPassword);
                smtpClient.Port = _smtpPort;
                smtpClient.EnableSsl = true;

                Console.WriteLine("Отправка письма...");

                await smtpClient.SendMailAsync(message);
                Console.WriteLine("Письмо отправлено успешно!");

                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при отправке письма: " + ex.Message); 
            return false;
        }
    }

}
