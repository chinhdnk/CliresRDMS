createCookie('page', 'login', 1);
$(document).ready(function () {
    if (perform_success == "perform_success") {
        confirm(msgValidate['sys_msg'], msgValidate['perform_success'], msgValidate['ok'], msgValidate['ok'], function () { return; });
    }
    $.validator.setDefaults({
        submitHandler: function () {
            SignIn();
        }
    });
    $('#FormLogin').validate({
        rules: {
            username: {
                required: true,
            },
            password: {
                required: true,
                minlength: 6 //for testing
                //minlength: 8
            }
        },
        messages: {
            username: {
                required: msgValidate['username_required'],
            },
            password: {
                required: msgValidate['password_required'],
                minlength: msgValidate['password_minlength']
            }
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.input-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });
});


var wrongtime = 0;
function SignIn() {
    $('#formLoading').show();
    $('#hdfWrongTimes').val(wrongtime);
    if (wrongtime > 4) {
        confirm(msg['sys_msg'], msg['account_locked'], msg['ok'], msg['ok'], function () { return; });
        $('#formLoading').hide();
        return;
    }

    var form = $('#FormLogin');
    var url = form.attr('action');

    $.ajax({
        type: 'POST',
        url: url,
        dataType: 'json',
        data: form.serialize(),
        success: function (data) {
            $('#formLoading').hide();
            if (data.success) {
                if (data.message === "pw_is_about_out_of_date") {
                    confirm(msg['sys_msg'], msg[data.message], msg['ok'], msg['ok'], function () { window.location.href = '/admin/admin'; });
                }
                else
                    window.location.href = '/admin/admin';
            } else {
                if (data.message === "username_pw_incorrect") {
                    confirm(msg['sys_msg'], msg[data.message], msg['ok'], msg['ok'], function () { return; });
                }
                else {
                    confirm(msg['sys_msg'], msg[data.message], msg['ok'], msg['ok'], function () { return; });
                    wrongtime = wrongtime + 1;
                }
            }
        }
    });
}
