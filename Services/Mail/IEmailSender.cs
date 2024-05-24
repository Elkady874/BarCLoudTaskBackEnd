using BarCLoudTaskBackEnd.DTOs.Stock;

namespace BarCLoudTaskBackEnd.Services.Mail
{
    public interface IEmailSender
    {
        void SendEmail(string toEmail, List<NewStockAggregateDTO> stocks);

    }
}
