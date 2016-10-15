
// initialize the validator function
validator.message.date = 'not a real date';

// validate a field on "blur" event, a 'select' on 'change' event & a '.reuired' classed multifield on 'keyup':
$('form')
  .on('blur', 'input[required], input.optional, select.required', validator.checkField)
  .on('change', 'select.required', validator.checkField)
  .on('keypress', 'input[required][pattern]', validator.keypress);

$('.multi.required').on('keyup blur', 'input', function() {
    validator.checkField.apply($(this).siblings().last()[0]);
});

$('form').submit(function(e) {
    e.preventDefault();
    var submit = true;

    // evaluate the form using generic validaing
    if (!validator.checkAll($(this))) {
        submit = false;
    }

    if (submit) {

        //this.submit();

        var conta = {
            'ID': 0,
            'NAME': $("#txtNome").val(),
            'PASSWORD': $("#txtSenha").val(),
            'PREMDAYS': $("#txtDiasPremium").val(),
            'LASTDAY': 0,
            'EMAIL': $("#txtEmail").val(),
            'KEY': 0,
            'BLOKED': false,
            'WARNINGS': 0,
            'GROUPID': $("#txtGrupoSeguranca").val()
        };

        PersistConta(conta);
    }

    return false;
});

function PersistConta(conta) {
    $.ajax({
        type: "GET",
        url: "Handler.ashx",
        contentType: "application/text; charset=utf-8",
        data: {
            method: 'PersistConta',
            Account: JSON.stringify(conta)
        },
        dataType: "json",
        cache: false,
        assync: false,
        success: function (result) {

            //alert(result);

            if (result != null) {
                //$('#divMsgSucesso').html(result).removeClass('hidden');
                document.getElementById("divMsgSucesso").innerHTML = result;
                var myButtonClasses = document.getElementById("divMsgSucesso").classList;
                if (myButtonClasses.contains("hidden")) {
                    myButtonClasses.remove("hidden");
                }
            }

        }
    }).fail(function () {
        alert('Erro ao cadastrar conta! ' + getErrorMessage(e));
        console.error(getErrorMessage(e));
    });

}