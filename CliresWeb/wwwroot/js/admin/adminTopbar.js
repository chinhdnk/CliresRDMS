$(document).ready(function () {
    $.validator.setDefaults({
        submitHandler: function () {
            changePass1();
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
    }, msg['pw_not_match']);

    $.validator.addMethod("NotHard", function (value, element) {
        var mediumRegex = new RegExp('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@@#\$%\^&\*])(?=.{6,})');
        var NewPassword = $("#NewPassword").val() || null;
        if (mediumRegex.test(NewPassword) === false) {
            return false;
        } else {
            return true;
        }

    }, msg['pw_not_hard']);

    $.validator.addMethod("OldMatch", function (value, element) {
        var rt = $.ajax({
            dataType: 'json',
            data: { pass: $("#OldPassword").val() },
            type: "GET",
            url: "/admin/checkOldPass",
            async: false
        }).responseText;
        if (rt === false) {
            return false;
        } else {
            return true;
        }

    }, msg['pw_not_hard']);

    $('#FormChangPass').validate({
        rules: {
            OldPassword: {
                required: true,
                minlength: 8,
                OldMatch: true
            },
            NewPassword: {
                required: true,
                minlength: 8,
                NotHard: true
            },
            ConfirmPassword: {
                required: true,
                minlength: 8,
                NotEqualTo: true
            }
        },
        messages: {
            OldPassword: {
                required: msg['password_required'],
                minlength: msg['password_minlength'],
                OldMatch: msg['pw_not_hard']
            },
            NewPassword: {
                required: msg['password_required'],
                minlength: msg['password_minlength'],
                NotHard: msg['pw_not_hard']
            },
            ConfirmPassword: {
                required: msg['password_required'],
                minlength: msg['password_minlength'],
                NotEqualTo: msg['pw_not_match']
            }
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });
});


function changePass() {
    $('#FormChangPass').submit();
}

function changePass1() {
    $('#formCPLoading').show();
    var form = $('#FormChangPass');
    var url = form.attr('action');

    $.ajax({
        type: "POST",
        url: url,
        dataType: 'json',
        data: form.serialize(), // serializes the form's elements.
        success: function (data) {
            $('#formCPLoading').hide();
            if (data.errorCode === "E500") {
                confirm(msg['system_error'], msg[data.message], msg['ok'], msg['ok'], function () { window.location.href = '/admin/error'; });
                return;
            }
            if (data.success) {
                alert(data.message);
                window.location.href = "/admin/signout";
            } else {
                var error = '<span id="OldPassword-error" class="error invalid-feedback">' + data.message + '</span>'
                
                $('#OldPassword').closest('.form-group').append(error);
                $('#OldPassword').addClass('is-invalid');
            }
        },
        error: function () {
            confirm(msg['system_error'], msg['system_error_message'], msg['ok'], msg['ok'], function () { window.location.href = '/admin/error'; });
        }
    });
}
