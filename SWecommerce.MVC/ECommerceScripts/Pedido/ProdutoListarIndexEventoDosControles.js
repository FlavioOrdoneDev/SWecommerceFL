$(document).ready(function () {

   $(".btn-adicionar").on("click", function () {        
        
        var carrinho = localStorage.getItem("carrinho");
        carrinho = JSON.parse(carrinho);
        if (carrinho == null)
            carrinho = [];
        var produto = {
            Id: $(this).closest('tbody').find('tr[id]').attr('id'),
            Produto: $(this).closest('tr').find('td[nome]').attr('nome'),
            Valor: $(this).closest('tr').find('td[preco]').attr('preco'),
            Quantidade: $(this).closest('tr').find('td[pro]').attr('pro'),
            Promocao: $(this).closest('tr').find('td[promocao]').attr('promocao'),
            Total: 0
        };
        
        var url = window.retornarURL("CalcularItem", "Home");
        $.ajax({
            url: url,
            dataType: "json",
            type: "GET",
            data: { produtoId: produto.Id, quantidade: 10 },
            cache: false,
            success: function (dados) {                
                
                produto.Quantidade = dados.Quantidade;
                produto.Preco      = dados.Preco;
                produto.Total      = dados.Total;
                produto.Mensagem   = dados.Mensagem;

                    Adicionar(carrinho, produto);
            }
        });        
   });    

   Listar();
   
   calcularCarrinho(carrinho);   
 
    $(function () {
        $("#moeda").maskMoney({
            symbol: 'R$ ',
            showSymbol: true, thousands: '.', decimal: ',', symbolStay: true
        });
    });

});
        

function Adicionar(carrinho,produto) {
    carrinho.push(produto);
    localStorage.setItem("carrinho", JSON.stringify(carrinho));
    Listar(carrinho);
    return true;
}

function Excluir() {
    carrinho.splice(indice_selecionado, 1);
    localStorage.setItem("carrinho", JSON.stringify(carrinho));
}


function Listar() {
    carrinho = localStorage.getItem("carrinho");
    carrinho2 = JSON.parse(carrinho)
    $("#tblListar").html("");
    $("#tblListar").html(
        "<thead>" +
        "   <tr>" +
        "   <th>Produto</th>" +
        "   <th>Quantidade</th>" +
        "   <th>Preço</th>" +
        "   <th>Promoção</th>" +        
        "   <th>Total</th>" +
        "   </tr>" +
        "</thead>" +
        "<tbody>" +
        "</tbody>"
        );
    for (var i in carrinho2) {
        var car = carrinho2[i];
        $("#tblListar tbody").append("<tr>");
        $("#tblListar tbody").append("<td>" + car.Produto + "</td>");
        $("#tblListar tbody").append("<td >" + car.Quantidade + "</td>");
        $("#tblListar tbody").append("<td class='moeda'>" + car.Valor + "</td>");
        $("#tblListar tbody").append("<td>" + car.Promocao + "</td>");
        $("#tblListar tbody").append("<td id='moeda'>" + car.Total + "</td>");
        $("#tblListar tbody").append("</tr>");
        $("#tblListar tbody").append("<td><button id='btnExcluir' class='btn btn-danger btn-sm '><i class='glyphicon glyphicon-trash'></i>&nbsp;&nbsp;&nbsp;Remover</button></td>");
    }
}

function calcularCarrinho(carrinho) {
    debugger;
    var tes = []
    var total = 0
    var carrinho3 = JSON.parse(carrinho);
    for (var i in carrinho3) {
        tes = carrinho3[i]
        total = total + tes.Total;
        $("#Total").text(total);
    }
};



