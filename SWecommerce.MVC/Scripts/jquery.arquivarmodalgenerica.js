/*!
 * jQuery Modal Generica
 * version: 1.0
 * Requer jQuery v1.10 ou Superior
 * Copyright (c) 2016 Arquivar.
 */

(function ($) {
    function montarModalGenerica(elemento, id, classe, URL, entradaJson, data, titulo, tamanho, funcaoFecharModal) {
        var $elemento = $(elemento);
        $elemento.children().remove();
        if ($elemento.data())
            $elemento.data("bs.modal", null);

        if (URL != null && data == null)
        {
            $.ajax({
                cache  : false,
                type   : "GET",
                global : false,
                url    : URL,
                data   :  entradaJson != null ? entradaJson : null,
                success: function (result)
                {
                    data = result;
                }
            });
        }

        if (id != null)
            $elemento.attr("id", id);

        $elemento.children().remove();
        
        $elemento.addClass("modal fade " + classe);
        $elemento.attr    ("tabindex", "-1"      );
        $elemento.attr    ("role", "dialog"      );
        $elemento.attr    ("aria-hidden", "true" );
        $elemento.attr    ("aria-labelledby", id == null ? $elemento.attr("id") : id);
        $elemento.attr    ("data-backdrop", "static" );
        $elemento.append('\
                            <div class="modal-dialog" style="width:'+ tamanho + '%" tabindex="-1">\
                                <div class="modal-content" style="heigth:initial !important";>\
                                  <div class="modal-header">\
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>\
                                    <h4 class="modal-title">'+ titulo + '</h4>\
                                  </div>\
                                  <div class="modal-body">\
                                        <div class="container">\
                                            <span hidden class="msg obrigatorio">Favor informar o(s) campo(s) obrigatório(s).</span>\
                                            <div class="dvMensagensModal"></div>\
                                        </div>\
                                    '+ data + "\
                                  </div>\
                                </div><!-- /.modal-content -->\
                            </div><!-- /.modal-dialog -->\
                        ");
        
        var i = 0;
        $elemento.on("hide.bs.modal", function () {
            if (i === 0)
            {
                if ($.isFunction(funcaoFecharModal))
                    funcaoFecharModal.call();
                else {
                    var funcao = window[String(funcaoFecharModal)];
                    if ($.isFunction(funcao))
                        funcao();
                }
                $("#dvMensagensModal").hide();
                $elemento.find(".msg").hide();
            }
            i++;
        });
        
        $elemento.modal({ keyboard: false });

        $elemento.on("show.bs.modal", function () {
            $(this).find(".modal-content").css({
                width: "auto", 
                height: "auto"
            });
        });
    }

    $.fn.modalGenerica = function (options)
    {
        var opts = $.extend({}, $.fn.modalGenerica.defaults, options);
        montarModalGenerica(this, opts.id, opts.classe, opts.URL, opts.entradaJson, opts.data, opts.titulo, opts.tamanho, opts.funcaoFecharModal);
    };

    $.fn.modalGenerica.defaults = {        
        tamanho: 80
    };
})(jQuery);