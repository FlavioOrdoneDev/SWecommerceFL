$(document).ready(function () {
    $("body").on("keyup blur", "input", function (e) {
        var keyCode = e.keyCode || e.which;
        var aux = 0;
        var msg = $("#hdnCampoObrigatorio").val();

        if (keyCode != 9 && keyCode != 16) {
            var data = $(this).data();
            if (data && data.required) {
                if ($(this).val().length > 0)
                    $(this).parent().removeClass("has-error");
                else {
                    $(this).parent().addClass("has-error");
                    aux = 1;
                }

                if (aux > 0) {
                    if (data.mensagem)
                        msg = data.mensagem;

                    if ($(".modal").is(":visible"))
                        ExibirMensagemDeErroModal(msg);
                    else
                        ExibirMensagemDeErro(msg);
                }
                else if ($(".has-error").length == 0)
                    $(".alert").alert("close");
            }
        }
    });
});