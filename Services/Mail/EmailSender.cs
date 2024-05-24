using System.Net.Mail;
using System.Net;
using System.Text;
using BarCLoudTaskBackEnd.DTOs.Stock;

namespace BarCLoudTaskBackEnd.Services.Mail
{
    public class EmailSender : IEmailSender
    {
       public void SendEmail(string toEmail,  List<NewStockAggregateDTO> stocks)
        {
            // Set up SMTP client
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("barcloudtask@gmail.com", "ltjj qxnt dkxs xniw");

            // Create email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("barcloudtask@gmail.com");
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = "Stock Price Update";
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<h1>Your Stocks Update</h1>");
             mailBody.AppendFormat("<br />");
            stocks.ForEach(stock => {
                mailBody.AppendFormat($"<h5>{stock.Name}</h5>");
                mailBody.AppendFormat($"<p>Highest Price was {stock.HighestPrice}</p>");
                mailBody.AppendFormat($"<p>Lowest Price was {stock.LowestPrice}</p>");
                mailBody.AppendFormat($"<p>Open Price was {stock.OpenPrice}</p>");
            });
            mailBody.AppendFormat("<p>Thank you For using BarCloud</p>");
            mailMessage.Body = mailBody.ToString();

            // Send email
            client.Send(mailMessage);
        }
    }
}
