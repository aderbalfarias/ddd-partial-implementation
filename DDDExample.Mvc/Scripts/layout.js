$(function () {
    $.fn.reloadSelect = function (data) {
        $(this).each(function (indexM, itemM) {
            var jThis = $(itemM);

            jThis.empty();
            jThis.append($('<option/>', {
                value: "",
                text: "Selecione"
            }));

            try {
                if (data.length > 0) {
                    $.each(data, function (index, item) {
                        jThis.append($('<option/>', {
                            value: item.Value,
                            text: item.Text
                        }));
                    });
                }
            } catch (e) {
                jThis.change();
            }
        });
    };

    $("#alert>.close").click(function () {
        $('#sectionAlert').removeClass("section-alert");
        $('#sectionAlert').addClass("display-none");
    });
});

//Mapeamento de rota
function UrlRota(controllerName, actionName) {
    var urlPath = $("#UrlPath").val();
    var urlRota = urlPath + controllerName + "/" + actionName;

    return urlRota;
}

////1=Sucesso, 2=Informacao, 3=aviso e 4=erro
// Depreciado - Substituido por: ShowMesage(kind, title, detail, timeoutSeg)
// Está aqui para garantir integridade do sistema até verificação de chamadas
// OBS: Chamadas antigas automaticamente caem no outro método, mesmo sem o 4º parametro 
function ShowMessage(kind, title, detail) {
    var timeoutSeg = 8;
    ShowMessage(kind, title, detail, timeoutSeg);
}

//1=Sucesso, 2=Informacao, 3=aviso e 4=erro
// No timeout = 30min para timeout da mensagem.
function ShowMessageNoTimeOut(kind, title, detail) {
    var timeoutSeg = 1800;
    ShowMessage(kind, title, detail, timeoutSeg);
}

//1=Sucesso, 2=Informacao, 3=aviso e 4=erro
// TimeoutSeg = tempo para o timeout da mensagem, em SEGUNDOS
function ShowMessage(kind, title, detail, timeoutSeg) {
    if (timeoutSeg == undefined) {
        timeoutSeg = 8;
    }
    var timeout = timeoutSeg * 1000;

    $('#sectionAlert').slideDown(function () {
        setTimeout(function () {
            $('#sectionAlert').slideUp(200);
        }, timeout);
    });       

    $('#alert').removeClass();

    $('#alert').addClass("alert");

    if (kind == "Information") {
        $('#alert').addClass('alert-info');
        $("#tipo").html("Informação: ");
    } else if (kind == "Success") {
        $('#alert').addClass('alert-success');
        $("#tipo").html("Sucesso: ");
    } else if (kind == "Warning") {
        $('#alert').addClass('alert-warning');
        $("#tipo").html("Alerta: ");
    } else if (kind == "Error") {
        $("#alert").addClass("alert-danger");
        $("#tipo").html("Erro: ");
    }

    if (title != null) {
        $("#title").html(title);
    }
}

function ConfirmDelete(url, name) {
    bootbox.confirm("Deseja realmente excluir o usuário " + name + "?", function (result) {
        if (result) {
            document.location.href = url;
        }
    });
}

function addFiltro(i, campo, idInput, hiddenAdd, parentAdd) {
    var conteudoAtual = $(hiddenAdd).val();
    var conteudoInserido = $(idInput).val();
    var appendId = "Append" + campo + i;

    $(hiddenAdd).val(conteudoAtual + conteudoInserido + ";");
 
    var texto = "<span id='" + appendId + "' class='text-append'>" +
        "<a href='#' onclick=\"removeFiltro(\'#" + appendId + "\', \'" + hiddenAdd + "\')\" class='control-label'>" +
        "<i class='fa fa-minus-square-o ajuste-append'></i></a>" + conteudoInserido + ", </span>";

    $(parentAdd).append(texto);
    $(idInput).val('');
}

function removeFiltro(id, itens) {
    var allItens = $(itens).val();
    var removeItem = $(id).text().replace(', ', ';');
    var newItens = allItens.replace(removeItem, '');

    $(itens).val(newItens);
    $(id).remove();
    return false;
}

function submitForm(form, div, url, idPag) {
    $("#ObjPagination_PaginaAtual").val(idPag);
    
    var model = $("#" + form).serialize();

    $(div).append("<div class='load text-center' tabindex='-1' role='dialog' aria-hidden='false'><i class='fa fa-spinner fa-pulse fa-5x'></i></div>");

    $.ajax({
        url: url,
        type: "POST",
        data: model ,
        dataType: "html",
        cache: false,
        async: true,
        success: function (data) {
            $(div).html(data);
        },
        error: function () {
            ShowMessage("Error", 'Ocorreu um problema ao tentar carregar dados', '');
        }
    });
}