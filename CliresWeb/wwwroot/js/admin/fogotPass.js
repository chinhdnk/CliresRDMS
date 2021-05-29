createCookie('page', 'login', 1);
$(document).ready(function () {
    $.validator.setDefaults({
        submitHandler: function () {
            SignIn();
        }
    });
    $('#FormLogin').validate({
        rules: {
            userName: {
                required: true,
            },
            email: {
                required: true,
                email: true,
            },
        },
        messages: {
            userName: {
                required: msgValidate['username_required'],
            },
            email: {
                required: msgValidate['email_required'],
                email: msgValidate['email_invalid'],
            },
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
    var form = $('#FormLogin');
    var url = form.attr('action');

    $.ajax({
        type: 'POST',
        url: url,
        dataType: 'json',
        data: form.serialize(),
        success: function (data) {
            $('#formLoading').hide();
            if (data.errorCode === "E500") {
                confirm(msg['system_error'], msg[data.message], msg['ok'], msg['ok'], function () { window.location.href = '/admin/error'; });
                return;
            }

            if (data.success) {
                confirm(msg['sys_msg'], msg['perform_success'], msg['ok'], msg['ok'], function () { window.location.href = '/admin/login'; });
            } else {
                confirm(msg['sys_msg'], data.message, 'Ok', 'Ok', function () { return; });
                wrongtime = wrongtime + 1;
            }
        },
        error: function () {
            confirm(msg['system_error'], msg['system_error_message'], msg['ok'], msg['ok'], function () { window.location.href = '/admin/error'; });
        }
    });
}

