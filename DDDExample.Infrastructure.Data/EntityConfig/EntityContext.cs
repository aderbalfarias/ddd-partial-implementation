using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DDDExample.Domain.Entities;

//using CodeFirstStoreFunctions;

namespace DDDExample.Infrastructure.Data.EntityConfig
{
    public class EntityContext : DbContext
    {
        #region Constructors

        public EntityContext()
            : base("Connection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<EntityContext>());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        #endregion
        
        #region Fields DbSet
        
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        #endregion

        #region Override Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(w => w.Name == (w.ReflectedType != null
                    ? w.ReflectedType.Name + "Id" : "Id"))
                    .Configure(c => c.IsKey());

            modelBuilder.Properties<string>()
                .Configure(c => c.HasColumnType("varchar"));

            modelBuilder.Properties<decimal>()
                .Configure(c => c.HasPrecision(10, 2));

            modelBuilder.Properties<string>()
                .Configure(c => c.HasMaxLength(100));
            
            modelBuilder.Configurations.Add(new PerfilConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());

            //Mapear function e procedure
            //modelBuilder.Conventions.Add(new FunctionsConvention<EntityContext>("dbo"));
        }

        #endregion

        #region Functions

        //[DbFunction("EntityContext", "ConsultaFatura_Detalhe")]
        //public IQueryable<vwConsultaFatura> ConsultaFatura_Detalhe(DateTime? pMovto, DateTime? pMovto1,
        //    string pDescricao)
        //{
        //    var pMovtoParameter = pMovto.HasValue
        //        ? new ObjectParameter("pMovto", pMovto)
        //        : new ObjectParameter("pMovto", typeof (DateTime));

        //    var pMovto1Parameter = pMovto1.HasValue
        //        ? new ObjectParameter("pMovto1", pMovto1)
        //        : new ObjectParameter("pMovto1", typeof (DateTime));

        //    var pDescricaoParameter = pDescricao != null
        //        ? new ObjectParameter("pDescricao", pDescricao)
        //        : new ObjectParameter("pDescricao", typeof (string));

        //    return ((IObjectContextAdapter) this).ObjectContext
        //        .CreateQuery<vwConsultaFatura>(
        //            string.Format("[{0}].{1}", GetType().Name,
        //                "[ConsultaFatura_Detalhe](@pMovto, @pMovto1, @pDescricao)"), pMovtoParameter, pMovto1Parameter,
        //            pDescricaoParameter);
        //}

        #endregion
    }
}
