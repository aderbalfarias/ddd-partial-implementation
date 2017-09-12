using DDDExample.Domain.Entities;
using DDDExample.Domain.Interfaces.Repositories;
using DDDExample.Domain.Interfaces.Services;

namespace DDDExample.Domain.Services
{
    public class PerfilService : ServiceBase<Perfil>, IPerfilService
    {
        #region Fields

        private readonly IPerfilRepository _perfilRepository;

        #endregion
        
        #region Constructors

        public PerfilService(IPerfilRepository perfilRepository)
            : base(perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        #endregion

        #region Methods

        #endregion
    }
}