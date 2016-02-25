$(function () {
    $("#cClassificacao").addClass("form-control");
  
    $('[mask]').each(function (e) {
        $(this).mask($(this).attr('mask'));
    });

    $('#Tipo').change(function () {
        var tipoSelected = $(this).find(":selected").val();

        if (tipoSelected === "0") {
            $("#CpfCnpj").mask("999.999.999-99");
        } else {
            $("#CpfCnpj").mask("99.999.999/9999-99");
        }
    });

    $("#Telefone, #Celular").mask("(99) 9999-9999").click();
    $("#CEP").mask("99999-999").click();
   

    $("#CEP").blur(function () {
        var cep = $('#Tipo').val().replace(/[^0-9]/, '');

        if (cep !== "") {

            var url = 'http://cep.correiocontrol.com.br/' + cep + '.json';

            $.getJSON(url, function (json) {
                $("#Endereco").val(json.logradouro);
                $("#Bairro").val(json.bairro);
                $("#Cidade").val(json.localidade);
                $("#UF").val(json.uf);

            });
        }
    });
    
});