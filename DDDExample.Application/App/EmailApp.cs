using DDDExample.Application.Interfaces;
using DDDExample.Domain.Entities;
using DDDExample.Domain.Interfaces.Services;

namespace DDDExample.Application.App
{
    public class EmailApp : IEmailApp
    {
        #region Fields

        private readonly IEmailService _emailService;

        #endregion

        #region Constructors

        public EmailApp(IEmailService emailService)
            //: base(emailService)
        {
            _emailService = emailService;
        }

        #endregion

        #region Methods

        public void SendEmail(Email entity)
        {
            _emailService.SendEmail(entity);
        }

        #endregion
    }
}
