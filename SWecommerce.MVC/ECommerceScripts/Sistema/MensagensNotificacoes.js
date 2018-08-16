function ExibirMensagemDeErro(mensagem) {
    var mensagens = $("#dvMensagens");
    var caixaDeErro = $("<div class=\"alert alert-danger fade in\"></div>")
    var botaoFechar = $("<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">×</button>");
    var icone = $("<i class=\"fa fa-times-circle fa-fw fa-lg\"></i>");

    $("#dvMensagens").html("");
    caixaDeErro.append(botaoFechar);
    caixaDeErro.append(icone);
    icone.after("<strong>  Erro! </strong>" + mensagem);
    mensagens.append(caixaDeErro);
    $(".alert-danger").fadeTo(10000, 500).slideUp(500, function () {
        $(".alert-danger").alert("close");
    });
    $("html, body").animate({ scrollTop: 0 }, "fast");
}

function ExibirMensagemDeSucesso(mensagem) {
    var mensagens = $("#dvMensagens");
    var caixaDeErro = $("<div class=\"alert alert-success fade in\"></div>")
    var botaoFechar = $("<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">×</button>");
    var icone = $("<i class=\"fa fa-check-circle fa-fw fa-lg\"></i>");

    $("#dvMensagens").html("");
    caixaDeErro.append(botaoFechar);
    caixaDeErro.append(icone);
    icone.after("<strong>  Ok! </strong>" + mensagem);
    mensagens.append(caixaDeErro);
    $(".alert-success").fadeTo(10000, 500).slideUp(500, function () {
        $(".alert-danger").alert("close");
    });
    $("html, body").animate({ scrollTop: 0 }, "fast");
}

function ExibirMensagemDeAlerta(mensagem) {

    var mensagens = $("#dvMensagens");
    var caixaDeErro = $("<div class=\"alert alert-warning fade in\"></div>")
    var botaoFechar = $("<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">×</button>");
    var icone = $("<i class=\"fa fa-warning fa-fw fa-lg\"></i>");

    $("#dvMensagens").html("");
    caixaDeErro.append(botaoFechar);
    caixaDeErro.append(icone);
    icone.after("<strong>  Atenção! </strong>" + mensagem);
    mensagens.append(caixaDeErro);
    $(".alert-warning").fadeTo(10000, 500).slideUp(500, function () {
        $(".alert-warning").alert("close");
    });
    $("html, body").animate({ scrollTop: 0 }, "fast");
}

function ExibirMensagemDeInformacao(mensagem) {

    var mensagens = $("#dvMensagens");
    var caixaDeErro = $("<div class=\"alert alert-info fade in\"></div>");
    var botaoFechar = $("<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">×</button>");
    var icone = $("<i class=\"fa fa-info-circle fa-fw fa-lg\"></i>");

    $("#dvMensagens").html("");
    caixaDeErro.append(botaoFechar);
    caixaDeErro.append(icone);
    icone.after("<strong>  Atenção! </strong>" + mensagem);
    mensagens.append(caixaDeErro);
    $(".alert-info").fadeTo(10000, 500).slideUp(500, function () {
        $(".alert-info").alert("close");
    });
    $("html, body").animate({ scrollTop: 0 }, "fast");
}

function ExibirMensagemDeErroModal(mensagem) {
    $("#dvMensagens").html("");
    var mensagens = $("#rhModal").is(":visible") ? $("#dvMensagensModal") : $($(".dvMensagensModal")[$(".dvMensagensModal").length - 1]);
    var caixaDeErro = $("<div class=\"alert alert-danger fade in\"></div>");
    var botaoFechar = $("<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">×</button>");
    var icone = $("<i class=\"fa fa-times-circle fa-fw fa-lg\"></i>");

    mensagens.html("");
    caixaDeErro.append(botaoFechar);
    caixaDeErro.append(icone);
    icone.after("<strong>  Erro! </strong>" + mensagem);
    mensagens.show();
    mensagens.append(caixaDeErro);
    $(".alert-danger").fadeTo(10000, 500).slideUp(500, function () {
        $(".alert-danger").alert("close");
    });
}

function ExibirMensagemDeSucessoModal(mensagem) {
    $("#dvMensagens").html("");
    var mensagens = $("#rhModal").is(":visible") ? $("#dvMensagensModal") : $($(".dvMensagensModal")[$(".dvMensagensModal").length - 1]);
    var caixaDeErro = $("<div class=\"alert alert-success fade in\"></div>");
    var botaoFechar = $("<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">×</button>");
    var icone = $("<i class=\"fa fa-check-circle fa-fw fa-lg\"></i>");

    mensagens.html("");
    caixaDeErro.append(botaoFechar);
    caixaDeErro.append(icone);
    icone.after("<strong>  Ok! </strong>" + mensagem);
    mensagens.append(caixaDeErro);
    mensagens.show();
    $(".alert-success").fadeTo(10000, 500).slideUp(500, function () {
        $(".alert-danger").alert("close");
    });
}

function ExibirMensagemDeAlertaModal(mensagem) {
    $("#dvMensagens").html("");
    var mensagens = $("#rhModal").is(":visible") ? $("#dvMensagensModal") : $($(".dvMensagensModal")[$(".dvMensagensModal").length - 1]);
    var caixaDeErro = $("<div class=\"alert alert-warning fade in\"></div>");
    var botaoFechar = $("<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">×</button>");
    var icone = $("<i class=\"fa fa-warning fa-fw fa-lg\"></i>");

    mensagens.html("");
    caixaDeErro.append(botaoFechar);
    caixaDeErro.append(icone);
    icone.after("<strong>  Atenção! </strong>" + mensagem);
    mensagens.append(caixaDeErro);
    mensagens.show();
    $(".alert-warning").fadeTo(10000, 500).slideUp(500, function () {
        $(".alert-warning").alert("close");
    });
}

function ExibirMensagemDeInformacaoModal(mensagem) {
    $("#dvMensagens").html("");
    var mensagens = $("#rhModal").is(":visible") ? $("#dvMensagensModal") : $($(".dvMensagensModal")[$(".dvMensagensModal").length - 1]);
    var caixaDeErro = $("<div class=\"alert alert-info fade in\"></div>");
    var botaoFechar = $("<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">×</button>");
    var icone = $("<i class=\"fa fa-info-circle fa-fw fa-lg\"></i>");

    mensagens.html("");
    caixaDeErro.append(botaoFechar);
    caixaDeErro.append(icone);
    icone.after("<strong>  Atenção! </strong>" + mensagem);
    mensagens.append(caixaDeErro);
    mensagens.show();
    $(".alert-info").fadeTo(10000, 500).slideUp(500, function () {
        $(".alert-info").alert("close");
    });
}
