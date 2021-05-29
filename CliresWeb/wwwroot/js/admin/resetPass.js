createCookie('page', 'login', 1);

$(document).ready(function () {
    if (valid === 'False') {
        confirm(msgValidate['sys_msg'], msgValidate['not_exist'], msgValidate['ok'], msgValidate['ok'], function () {
            createCookie('page', 'login', 1);
            window.location.href = '/admin/login';
        });
    }
    $.validator.setDefaults({
        submitHandler: function () {
            SignIn();
        }
    });

    $.validator.addMethod("NotEqualTo", function (value, element) {
        var NewPassword = $("#NewPassword").val() || null;
        if (value == NewPassword) {
            return true; //Error fire!
        }
        else {
            return false; //Error Not fire!
        }
    }, msgValidate['pw_not_match']);

    $.validator.addMethod("NotHard", function (value, element) {
        var mediumRegex = new RegExp('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@@#\$%\^&\*])(?=.{6,})');
        var NewPassword = $("#NewPassword").val() || null;
        if (mediumRegex.test(NewPassword) === false) {
            return false;
        } else {
            return true;
        }

    }, msgValidate['pw_not_hard']);

    $.validator.addMethod("OldMatch", function (value, element) {
        var rt = $.ajax({
            dataType: 'json',
            data: { pass: $("#OldPassword").val() },
            type: "GET",
            url: "/admin/checkOldPass",
            async: false
        }).responseText;
        debugger;
        if (rt === false) {
            return false;
        } else {
            return true;
        }

    }, msgValidate['pw_not_hard']);

    $('#FormLogin').validate({
        rules: {
            NewPassword: {
                required: true,
                minlength: 8,
                NotHard: true
            },
            ReNewPassword: {
                required: true,
                minlength: 8,
                NotEqualTo: true
            },
        },
        messages: {
            NewPassword: {
                required: msgValidate['password_required'],
                minlength: msgValidate['password_minlength'],
                NotHard: msgValidate['pw_not_hard']
            },
            ReNewPassword: {
                required: msgValidate['password_required'],
                minlength: msgValidate['password_minlength'],
                NotEqualTo: msgValidate['pw_not_match']
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
    var form = $('#FormLogin');
    var url = form.attr('action');
    var id = $('#hdfKeyReset').val();
    var pass = $('#ReNewPassword').val();
    var username = $('#hdfUserName').val();
    var email = $('#hdfEmail').val();
    $.ajax({
        type: 'POST',
        url: url,
        dataType: 'json',
        data: { id: id, pass: pass, username: username, email: email }, // serializes the form's elements.
        success: function (data) {
            $('#formLoading').hide();
            if (data.errorCode === "E500") {
                confirm(msg['system_error'], msg[data.message], msg['ok'], msg['ok'], function () { window.location.href = '/admin/error'; });
                return;
            }
            if (data.success) {
                confirm(msg['sys_msg'], msg['pw_reset_success'], msg['ok'], msg['ok'], function () { window.location.href = '/admin/login'; });

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


