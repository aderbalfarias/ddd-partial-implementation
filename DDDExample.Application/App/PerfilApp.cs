using DDDExample.Application.Interfaces;
using DDDExample.Domain.Entities;
using DDDExample.Domain.Interfaces.Services;

namespace DDDExample.Application.App
{
    public class PerfilApp : AppBase<Perfil>, IPerfilApp
    {
        #region Fields

        private readonly IPerfilService _perfilService;

        #endregion
        
        #region Constructors

        public PerfilApp(IPerfilService perfilService)
            : base(perfilService)
        {
            _perfilService = perfilService;
        }

        #endregion

        #region Methods

        #endregion
    }
}
