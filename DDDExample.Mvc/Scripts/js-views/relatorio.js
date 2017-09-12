$(function () {
    $("#ProcessamentoInicial").datepicker({ altFormat: "dd-MM-yyyy" });
    $("#ProcessamentoFinal").datepicker({ altFormat: "dd-MM-yyyy" });

    $("#ProcessamentoInicial").change(function () {
        $(this).datepicker('hide');
    });

    $("#ProcessamentoFinal").change(function () {
        $(this).datepicker('hide');
    });


    $("#PostagemInicial").datepicker({ altFormat: "dd-MM-yyyy" });
    $("#PostagemFinal").datepicker({ altFormat: "dd-MM-yyyy" });

    $("#PostagemInicial").change(function () {
        $(this).datepicker('hide');
    });

    $("#PostagemFinal").change(function () {
        $(this).datepicker('hide');
    });


    $("#DevolucaoInicial").datepicker({ altFormat: "dd-MM-yyyy" });
    $("#DevolucaoFinal").datepicker({ altFormat: "dd-MM-yyyy" });

    $("#DevolucaoInicial").change(function () {
        $(this).datepicker('hide');
    });

    $("#DevolucaoFinal").change(function () {
        $(this).datepicker('hide');
    });

    $("div").delegate("#Exportar", "click", function () {
        var form = $("form#RelatorioFiltrosForm");
        form.attr("action", UrlRota("Relatorio", "Download"));
        form.submit();

        form.attr("action", UrlRota("Relatorio", "List"));
    });
});
