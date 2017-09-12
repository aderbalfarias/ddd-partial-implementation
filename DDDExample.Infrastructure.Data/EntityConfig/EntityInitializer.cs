using DDDExample.Domain.Entities;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace DDDExample.Infrastructure.Data.EntityConfig
{
    public class EntityInitializer : CreateDatabaseIfNotExists<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            context.Perfil.AddRange(
                new Collection<Perfil>
                {
                    new Perfil
                    {
                        Descricao = "Administrador",
                        Ativo = true,
                        Usuario = new Collection<Usuario>
                        {
                            new Usuario
                            {
                                Nome = "Aderbal Farias",
                                Email = "teste@teste.com.br",
                                Login = "aderbal.farias",
                                Senha = "T8BDdQokQd79jjXS4j6E8A==",
                                DataCadastro = DateTime.Now,
                                Ativo = true
                            }
                        }
                    },
                    new Perfil
                    {
                        Descricao = "Usuário",
                        Ativo = true,
                        Usuario = new Collection<Usuario>
                        {
                            new Usuario
                            {
                                Nome = "Teste",
                                Email = "teste@teste.com",
                                Login = "teste.teste",
                                Senha = "T8BDdQokQd79jjXS4j6E8A==",
                                DataCadastro = DateTime.Now,
                                Ativo = true
                            }
                        }
                    }
                }
            );

            context.SaveChanges();
        }
    }
}
