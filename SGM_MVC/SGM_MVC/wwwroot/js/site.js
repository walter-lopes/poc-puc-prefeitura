// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#CpfCnpj").keypress(function () {
    try {
        $("#CpfCnpj").unmask();
        var tamanho = $("#CpfCnpj").val().length;
        if (tamanho < 11) {
            $("#CpfCnpj").mask("999.999.999-99");
        } else if (tamanho >= 11){
            $("#CpfCnpj").mask("99.999.999/9999-99");
        }
    } catch (e) { }

    //// ajustando foco
    //var elem = this;
    //setTimeout(function () {
    //    // mudo a posição do seletor
    //    elem.selectionStart = elem.selectionEnd = 10000;
    //}, 0);
    //// reaplico o valor para mudar o foco
    //var currentValue = $(this).val();
    //$(this).val('');
    //$(this).val(currentValue);
});


$("#telefone").keypress(function () {
    try {
        $("#telefone").unmask();
        var tamanho = $("#telefone").val().length;
        if (tamanho < 10) {
            $("#telefone").mask("(99)9999-9999");
        } else if (tamanho >= 10) {
            $("#telefone").mask("(99)99999-9999");
        }
    } catch (e) { }
});

$("#cep").keypress(function () {
    try {
        $("#cep").mask("99999-999");
    } catch (e) { }
});