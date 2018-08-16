$(document).ready(function () {
    
    var msg = sessionStorage.getItem("msg");
    if (msg) {
        ExibirMensagemDeSucesso(msg);
        sessionStorage.removeItem("msg");
    }

    $("#tabelaProdutos tr").on("click", function () {
        if (!$(this).hasClass("trNenhumRegistro")) {
            $("#iconeAlterar, #iconeExcluir").removeClass("iconeDesabilitado");
            $("#tabelaProdutos tr").removeClass("itemAtivo").removeAttr("style");
            $(this).addClass("itemAtivo");
        }
    });

    $("#btn_incluir").on("click", function () {
        debugger;
        var url = window.retornarURL("PartialCadastrarProduto", "Produto");
        $.ajax({
            url: url,
            type: "GET",
            cache: false,
            success: function (retorno) {
                if (retorno.Result != null)
                    ExibirMensagemDeErro(retorno.Data);
                else
                    exibirModalProduto($("Cadastrar Produto").val(), retorno);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                ExibirMensagemDeErro(thrownError);
            }
        });
    });

    
    $(".btn-alterar").on("click", function () {
        if (!$(this).hasClass("iconeDesabilitado")) {
            var url = window.retornarURL("PartialAlterarProduto", "Produto");
            var btn = $(this);
            var produtoId = btn.closest('tr').attr('data-id');

            $.ajax({
                url: url,
                type: "GET",
                data: { produtoId: produtoId },
                cache: false,
                success: function (retorno) {
                    if (retorno.Result != null)
                        ExibirMensagemDeErro(retorno.Data);
                    else
                        exibirModalProduto($("#hdnMsgAlterarProduto").val(), retorno);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    ExibirMensagemDeErro(thrownError);
                }
            });
        }
    });

    $(".btn-excluir").on("click", function () {
        debugger;
        var btn = $(this),
            tr = btn.closest('tr'),
            id = tr.attr('data-id'),
            url = '@Url.Action("ExcluirProduto", "Produto")',
            param = { 'id': id };
        $.confirm({
            title: $("#hdnAtencao").val(),
            text: $("#hdnMsgExclusao").val(),
            confirm: function () {
                debugger;
                var url = window.retornarURL("ExcluirProduto", "Produto");
                var btn = $(this);
                var produtoId2 = $($(".itemAtivo")[0]).children(":first").text();
                var produtoId = id

                $.ajax({
                    url: url,
                    type: "Delete",
                    data: { produtoId: produtoId },
                    cache: false,
                    success: function (retorno) {
                        if (retorno.Result != "OK")
                            ExibirMensagemDeErro(retorno.Data);
                        else {
                            sessionStorage.setItem("msg", retorno.Data);
                            location.reload();
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        ExibirMensagemDeErro(thrownError);
                    }
                });
            },
            confirmButton: $("#hdnSim").val(),
            cancelButton: $("#hdnNao").val(),
            post: true,
            confirmButtonClass: "btn-primary",
            cancelButtonClass: "btn-default"
        });
    });

    
    });

    function exibirModalProduto(titulo, conteudo) {
        $(".alert").alert("close");
        $("#modalDadosProduto").modalGenerica({
            data: conteudo,
            titulo: titulo,
            tamanho: 90,
            funcaoFecharModal: function () {
                //callback;
            }
        });
    }