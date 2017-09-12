using DDDExample.Domain.Entities;

namespace DDDExample.Domain.Interfaces.Services
{
    public interface IEmailService
    {
        void SendEmail(Email entity);
    }
}
