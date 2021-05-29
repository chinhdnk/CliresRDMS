createCookie('page', 'user_detail', 1);
var actionsubmit;

$(document).ready(function () {
    $('#ExpiredDate').datepicker({
        timepicker: false,
        dateFormat: 'dd/mm/yy',
        inline: false,
        lang: 'en'
    });

    $.validator.setDefaults({
        submitHandler: function () {
            SaveDataUser1(actionsubmit);
        }
    });

    $.validator.addMethod("CheckUser", function (value, element) {
        if (actionsubmit != 4 && actionsubmit != 2 && actionsubmit != 3) {
            var rt = $.ajax({
                dataType: 'json',
                data: { user: $("#UserName").val() },
                type: "GET",
                url: "/admin/CheckUserEmail",
                async: false
            }).responseText;
            if (rt === 'false') {
                return true;
            } else {
                return false;
            }
        }
        else
            return true;
    }, msgValidate['account_exist']);

    $.validator.addMethod("CheckEmail", function (value, element) {
        if (actionsubmit != 4 && actionsubmit != 2 && actionsubmit != 3) {
            var rt = $.ajax({
                dataType: 'json',
                data: { email: $("#Email").val() },
                type: "GET",
                url: "/admin/CheckUserEmail",
                async: false
            }).responseText;
            if (rt === 'false') {
                return true;
            } else {
                return false;
            }
        }
        else
            return true;
    }, msg['email_taken']);

    $('#frmUser').validate({
        rules: {
            UserName: {
                required: true,
                maxlength: 15,
                CheckUser: (Obj.isAdd==1)
            },
            FullName: {
                required: true,
                maxlength: 30
            },
            Email: {
                required: true,
                email: true,
                CheckEmail: (Obj.isAdd == 1)
            },
            OfficeNumber: {
                maxlength: 12
            },
            PhoneNumber: {
                maxlength: 12
            },
        },
        messages: {
            UserName: {
                required: msgValidate['required_user_name'],
                maxlength: msgValidate['user_name_maxlength'],
                CheckUser: msgValidate['account_exist'],
            },
            FullName: {
                required: msgValidate['required_full_name'],
                maxlength: msgValidate['full_name_maxlength'],
            },
            Email: {
                required: msgValidate['required_email'],
                email: msgValidate['required_valid_email'],
                CheckEmail: msgValidate['email_taken']
            },
            OfficeNumber: {
                maxlength: msgValidate['phone_maximum']
            },
            PhoneNumber: {
                maxlength: msgValidate['phone_maximum']
            },
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


function SaveDataUser(action) {
    actionsubmit = action;
    $('#frmUser').submit();
}

function SaveDataUser1(action) {
    actionsubmit = action;
    //Active user
    if (action === 1) {
        $('#hdfStatus').val(1);
    } else if (action === 2) {
        $('#hdfStatus').val(2);
    }
    //Extend 
    else if (action === 3) {
        var d = new Date();
        var mm = d.getMonth() + 1;
        var dd = d.getDate();
        var yy = d.getFullYear();
        mm = mm < 10 ? '0' + mm : mm;
        dd = dd < 10 ? '0' + dd : dd;
        $('#hdfDateNow').val(dd + '/' + mm + '/' + yy);

        if (CompareDate($('#ExpiredDate').val(), $('#hdfDateNow').val()) === true) {
            confirm(msg['sys_msg'], msg['account_expired'], msg['ok'], msg['ok'], function () { $('#ExpiredDate').focus(); return; });
            return;
        }

        $('#hdfStatus').val(1);
    }
    else {
        $('#hdfStatus').val('');
    }

    $('#hdfAction').val(action);
    //Get check permission
    var lstPer = $("#PermissionList input[type='checkbox'][name='PermissionName']:checked").map(function () { return $(this).data('id'); }).get();
    $('#hdfPermissionList').val(lstPer.join(','));
    //Get check group
    var lstGp = $("#GroupList input[type='checkbox'][name='GroupName']:checked").map(function () { return $(this).data('id'); }).get();
    $('#hdfGroupList').val(lstGp.join(','));

    var frm = new FormData($('#frmUser')[0]);
    var url = $('#frmUser').attr('action');
    $.ajax({
        type: 'POST',
        url: url,
        contentType: false,
        processData: false,
        data: frm,
        success: function (data) {
            if (data.errorCode === "E500") {
                confirm(msg['system_error'], msg[data.message], msg['ok'], msg['ok'], function () { window.location.href = '/admin/error'; });
                return;
            }
            if (data.success) {
                if (actionsubmit === 1 || actionsubmit === 2) {
                    var keyString = actionsubmit === 1 ? "account_unlock_success" :"account_locked_success";
                    confirm(msg['sys_msg'], msg[keyString], msg['ok'], msg['ok'], function () { window.location.reload(); });
                }
                else
                    window.location.href = '/admin/usermanager';
            }
        },
        error: function () {
            confirm(msg['system_error'], msg['system_error_message'], msg['ok'], msg['ok'], function () { window.location.href = '/admin/error'; });
        }
    });
}

function ResetPassword(user) {
    var callback = function () {
        $.ajax({
            type: 'POST',
            url: '/admin/resetpassword',
            dataType: 'json',
            data: { user }, // serializes the form's elements.
            success: function (data) {
                if (data.success) {
                    confirm(msg['sys_msg'], msg['perform_success'], msg['ok'], msg['ok'], function () { return; });
                    // window.location.href = '/admin/usermanager';
                }
                console.log(data); // show response from the php script.
            }
        });
    };

    // confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
    confirm(msg['sys_msg'], msg['cfrm_rest_pass'], msg['cancel'], msg['confirm'], callback);
}

function validateFileType(event, id) {
    ischangimage = true;
    var fileName = document.getElementById(id).value;
    var idxDot = fileName.lastIndexOf('.') + 1;
    var extFile = fileName.substr(idxDot, fileName.length).toLowerCase();
    if (extFile === 'jpg' || extFile === 'jpeg' || extFile === 'png' || extFile === 'gif') {
        var file = event.target.files[0];
        if (file.size / 1024 / 1024 > 1) {
            alert('This file size is: ' + (file.size / 1024 / 1024).toFixed(2) + ' MB, please chosen file less than 1 MB');
            return;
        } else {
            var output = document.getElementById('View' + id);
            output.src = URL.createObjectURL(event.target.files[0]);
            var reader = new FileReader();
            reader.onloadend = function () {
                console.log('RESULT', reader.result);
                $('#hdf' + id).val(reader.result);
                $('#hdfIsChange' + id).val(1);
            }
            reader.readAsDataURL(file);
        }

    } else {
        alert('Only jpg/jpeg and png files are allowed!');
    }
}

