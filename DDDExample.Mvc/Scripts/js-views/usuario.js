$(function () {
    //$("#PerfilId").change(function () {
    //    $("#ListPermissoesId").removeClass();
    //    $("#ListPermissoesId > label").remove();
    //    $("#ListPermissoesId > div").remove();

    //    if ($(this).val() != 0) {
    //        $.ajax({
    //            url: UrlRota("Usuario", "ListarPermissao"),
    //            type: "GET",
    //            data: { id: $(this).val() },
    //            dataType: "json",
    //            cache: false,
    //            success: function (data) {
    //                $("#ListPermissoesId").addClass('form-group');
    //                $("#ListPermissoesId").append("<label class='control-label col-md-2' for='Permissoes'>Permissões do Perfil</label>");
    //                $("#ListPermissoesId").append("<div class='col-md-10 text-list' id='PermissoesId'>");
    //                $("#PermissoesId").append("<div class='col-md-3 text-form-adjust' id='MenuItemId'><b><i class='fa fa-hand-o-down'></i> Menu</b></div>");
    //                //$("#PermissoesId").append("<div class='col-md-3 text-form-adjust' id='TipoEnvioItemId'><b><i class='fa fa-hand-o-down'></i> Envio de Reimpressão</b></div>");

    //                var menus = data.Menus.toString().split(",");
    //                $(menus).each(function (i) {
    //                    $("#MenuItemId").append("<div><i class='fa fa-check-square-o'></i> " + menus[i] + "</div>");
    //                });

    //                //var tiposEnvio = data.TiposEnvio.toString().split(",");
    //                //$(tiposEnvio).each(function (i) {
    //                //    $("#TipoEnvioItemId").append("<div><i class='fa fa-check-square-o'></i> " + tiposEnvio[i] + "</div>");
    //                //});
    //            },
    //            error: function () {
    //                ShowMessage("Error", 'Ocorreu um problema ao tentar listar permissões do perfil', '');
    //            }
    //        });
    //    }
    //});
});

