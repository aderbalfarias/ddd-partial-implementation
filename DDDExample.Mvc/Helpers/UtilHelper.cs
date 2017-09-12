using System;
using System.Globalization;
using System.Web.Mvc;

namespace DDDExample.Mvc.Helpers
{
    public static class UtilHelper
    {
        /// <summary>
        /// Paginção de lista
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="helper">Helper</param>
        /// <param name="url">Caminho da action</param>
        /// <param name="pagAtual">Página que recebeu o evento</param>
        /// <param name="qtdePag">Quantidade de páginas existentes</param>
        /// <param name="formId">Formulário para serializar</param>
        /// <param name="divLocation">Div para retorno da paginação</param>
        /// <param name="beginEnd">Indica se a paginação contem os elementos inicial e final</param>
        /// <returns>Elemento nav com itens para paginação de dados</returns>
        public static MvcHtmlString Pagination<TModel>(this HtmlHelper<TModel> helper, string url, int pagAtual, int qtdePag, string formId = null, string divLocation = null, bool beginEnd = true)
        {
            var nav = new TagBuilder("nav");
            nav.AddCssClass("text-center");

            var ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");

            var liBegin = new TagBuilder("li")
            {
                InnerHtml = formId != null && divLocation != null
                    ? (pagAtual != 1 ?
                        $"<a href=\"#\" onclick=\"submitForm('{formId}', '#{divLocation}', '{url}', '{1}')\" aria-label=\"Previous\"><span aria-hidden=\"true\">&laquo;</span></a>"
                        : "<a aria-label=\"Previous\"><span aria-hidden=\"true\">&laquo;</span></a>")
                    : (pagAtual != 1 ?
                        $"<a href=\"{url}?idPag={1}\" aria-label=\"Previous\"><span aria-hidden=\"true\">&laquo;</span></a>"
                        : "<a aria-label=\"Previous\" class=\"disabled\"><span aria-hidden=\"true\">&laquo;</span></a>")
            };

            var liPrevious = new TagBuilder("li")
            {
                InnerHtml = formId != null && divLocation != null
                    ? (pagAtual != 1 ?
                        $"<a href=\"#\" onclick=\"submitForm('{formId}', '#{divLocation}', '{url}', '{(pagAtual - 1)}')\" aria-label=\"Previous\"><span aria-hidden=\"true\">&lsaquo;</span></a>"
                        : "<a aria-label=\"Previous\"><span aria-hidden=\"true\">&lsaquo;</span></a>")
                    : (pagAtual != 1 ?
                        $"<a href=\"{url}?idPag={(pagAtual - 1)}\" aria-label=\"Previous\"><span aria-hidden=\"true\">&lsaquo;</span></a>"
                        : "<a aria-label=\"Previous\" class=\"disabled\"><span aria-hidden=\"true\">&lsaquo;</span></a>")
            };

            if (pagAtual == 1)
            {
                liBegin.AddCssClass("disabled");
                liPrevious.AddCssClass("disabled");
            }

            var liList = (beginEnd ? liBegin.ToString(TagRenderMode.Normal) : null) + liPrevious.ToString(TagRenderMode.Normal);

            int maxPag = qtdePag > 5 ? 5 : qtdePag;

            for (int i = 0; i < maxPag; i++)
            {
                int numPag;
                if (maxPag < 5)
                {
                    numPag = i + 1;
                }
                else if (pagAtual < 3 || (pagAtual + 2) > qtdePag)
                {
                    switch ((qtdePag - pagAtual))
                    {
                        case 0:
                            numPag = (pagAtual - 4) + i;
                            break;
                        case 1:
                            numPag = (pagAtual - 3) + i;
                            break;
                        case 2:
                            numPag = (pagAtual - 2) + i;
                            break;
                        case 3:
                            numPag = (pagAtual - 1) + i;
                            break;
                        default:
                            numPag = pagAtual + i;
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            numPag = pagAtual - 2;
                            break;
                        case 1:
                            numPag = pagAtual - 1;
                            break;
                        case 2:
                            numPag = pagAtual;
                            break;
                        case 3:
                            numPag = pagAtual + 1;
                            break;
                        case 4:
                            numPag = pagAtual + 2;
                            break;
                        default:
                            numPag = 0;
                            break;
                    }
                }

                var li = new TagBuilder("li")
                {
                    InnerHtml = formId != null && divLocation != null
                        ? $"<a href=\"#\" onclick=\"submitForm('{formId}', '#{divLocation}', '{url}', '{numPag}')\">{numPag} <span class=\"sr-only\">(current)</span></a>"
                        : $"<a href=\"{url}?idPag={numPag}\">{numPag} <span class=\"sr-only\">(current)</span></a>"
                };

                if (numPag == pagAtual)
                    li.AddCssClass("active");

                liList = liList + li.ToString(TagRenderMode.Normal);
            }

            var liNext = new TagBuilder("li")
            {
                InnerHtml = formId != null && divLocation != null
                    ? (pagAtual != qtdePag ?
                        $"<a href=\"#\" onclick=\"submitForm('{formId}', '#{divLocation}', '{url}', '{(pagAtual + 1)}')\" aria-label=\"Next\"><span aria-hidden=\"true\">&rsaquo;</span></a>"
                        : "<a aria-label=\"Next\"><span aria-hidden=\"true\">&rsaquo;</span></a>")
                    : (qtdePag != pagAtual ?
                        $"<a href=\"{url}?idPag={(pagAtual + 1)}\" aria-label=\"Next\"><span aria-hidden=\"true\">&rsaquo;</span></a>"
                        : "<a aria-label=\"Next\" class=\"disabled\"><span aria-hidden=\"true\">&rsaquo;</span></a>")
            };

            var liEnd = new TagBuilder("li")
            {
                InnerHtml = formId != null && divLocation != null
                    ? (pagAtual != qtdePag ?
                        $"<a href=\"#\" onclick=\"submitForm('{formId}', '#{divLocation}', '{url}', '{qtdePag}')\" aria-label=\"Next\"><span aria-hidden=\"true\">&raquo;</span></a>"
                        : "<a aria-label=\"Next\"><span aria-hidden=\"true\">&raquo;</span></a>")
                    : (qtdePag != pagAtual ?
                        $"<a href=\"{url}?idPag={qtdePag}\" aria-label=\"Next\"><span aria-hidden=\"true\">&raquo;</span></a>"
                        : "<a aria-label=\"Next\" class=\"disabled\"><span aria-hidden=\"true\">&raquo;</span></a>")
            };

            if (pagAtual == qtdePag)
            {
                liNext.AddCssClass("disabled");
                liEnd.AddCssClass("disabled");
            }

            ul.InnerHtml = liList + liNext.ToString(TagRenderMode.Normal) + (beginEnd ? liEnd.ToString(TagRenderMode.Normal) : null);
            nav.InnerHtml = ul.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(nav.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Display em tabela
        /// </summary>
        /// <param name="helper">Helper</param>
        /// <param name="text">Texto que será exibido</param>
        /// <param name="cols">Quantidade de colunas da table</param>
        /// <param name="html">Html para customização</param>
        /// <returns>Elemento tr para ser incluso em uma table</returns>
        public static MvcHtmlString DisplayTrInfo(this HtmlHelper helper, string text, int cols, Object html = null)
        {
            var tr = new TagBuilder("tr");
            var td = new TagBuilder("td");
            var b = new TagBuilder("b");

            td.MergeAttribute("colspan", cols.ToString(CultureInfo.InvariantCulture));
            td.HtmlAtributosCustom(html);

            b.InnerHtml = text; 
            td.InnerHtml = b.ToString(TagRenderMode.Normal);
            tr.InnerHtml = td.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(tr.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Separador de conteúdo
        /// </summary>
        /// <param name="helper">Helper</param>
        /// <param name="cssClass">class css</param>
        /// <param name="html">Html para customização</param>
        /// <returns>Elemento hr para separar conteúdo</returns>
        public static MvcHtmlString Separador(this HtmlHelper helper, string cssClass = null, Object html = null)
        {
            var tag = new TagBuilder("hr"); //gera uma tag input no html

            if (cssClass != null)
                tag.AddCssClass(cssClass);

            if (html != null)
                tag.HtmlAtributosCustom(html);

            var hr = MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));

            return hr;
        }
    }
}
