using System;

namespace DDDExample.Domain.Entities
{
    public class Pagination
    {
        public Pagination()
        {
            QtdeItensPagina = 10;
        }

        public int QtdeItensPagina { get; set; }

        public int QtdePaginas { get; set; }

        public int PaginaAtual { get; set; }

        public int SkipPagina(Pagination entity)
        {
            return entity.PaginaAtual > 1
                ? (entity.PaginaAtual - 1) * entity.QtdeItensPagina : 0;
        }

        public Pagination CalcularPagination(Pagination entity, int count)
        {
            return new Pagination
            {
                QtdePaginas = (int) Math.Ceiling(count/Convert.ToDouble(entity.QtdeItensPagina)),
                PaginaAtual = entity.PaginaAtual != 0 ? entity.PaginaAtual : 1
            };
        }
    }
}
