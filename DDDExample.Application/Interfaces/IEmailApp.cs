using DDDExample.Domain.Entities;

namespace DDDExample.Application.Interfaces
{
    public interface IEmailApp
    {
        void SendEmail(Email entity);
    }
}
