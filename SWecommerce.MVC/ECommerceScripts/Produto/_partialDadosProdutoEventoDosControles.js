$(document).ready(function () {
    if ($("#hdnIdProduto").val() == "")
        $("#formDadosCadastraisProduto").attr("action", window.retornarURL("CadastrarProduto", "Produto"));
    else
        $("#formDadosCadastraisProduto").attr("action", window.retornarURL("AlterarProduto", "Produto"));

    $("#btnSalvarDadosCadastrais").on("click", function (e) {
        var camposValidacao = $("[data-required='true']");
        var msgErro = $("#hdnCampoObrigatorio").val();

        $.each(camposValidacao, function (idx, obj) {
            var elemento = $(obj);
            if (elemento.val() == "") {
                elemento.parent().addClass("has-error");
                var data = elemento.data();
                if (data && data.mensagem)
                    msgErro = data.mensagem;

                ExibirMensagemDeErroModal(msgErro);

                e.preventDefault();
            }
        });
    });

    $("#formDadosCadastraisProduto").ajaxForm(function (result) {
        debugger;
        if (result.Result == "OK") {
            sessionStorage.setItem("msg", result.Data);
            location.reload();
        }
        else
            ExibirMensagemDeErroModal(result.Data);
    });
});

