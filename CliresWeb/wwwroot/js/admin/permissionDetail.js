createCookie('page', 'permission_detail', 1);
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
            SaveDataSubmit(actionsubmit);
        }
    });

    $.validator.addMethod("CheckPermissionExist", function (value, element) {
        if (Obj.isAdd === 1) {
            var rt = $.ajax({
                dataType: 'json',
                data: { name: $("#PermissionName").val() },
                type: "GET",
                url: "/admin/CheckPermissionExist",
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
    }, msg['permission_name_exist']);


    $('#frmDetail').validate({
        rules: {
            PermissionName: {
                required: true,
                CheckPermissionExist: true,
            },
        },
        messages: {
            PermissionName: {
                required: 'Please enter Username',
                CheckPermissionExist: msg['permission_name_exist']
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

function SaveData(action) {
    actionsubmit = action;
    $('#frmDetail').submit();
}

function SaveDataSubmit(action) {
    actionsubmit = action;
    //Add new Permission

    if (action === 1) {
        $('#hdfStatus').val(1);
    } else if (action === 2) {
        $('#hdfStatus').val(2);
    }
    else {
        $('#hdfStatus').val('');
    }

    $('#hdfAction').val(action);
    var form = $('#frmDetail');
    var url = form.attr('action');

    $.ajax({
        type: 'POST',
        url: url,
        dataType: 'json',
        data: form.serialize(),
        success: function (data) {
            if (data.errorCode === "E500") {
                confirm(msg['system_error'], msg[data.message], msg['ok'], msg['ok'], function () { window.location.href = '/admin/error'; });
                return;
            }
            if (actionsubmit === 1 || actionsubmit === 2) {
                var keyString = actionsubmit === 1 ? "unlock_success" : "locked_success";
                confirm(msg['sys_msg'], msg[keyString], msg['ok'], msg['ok'], function () { window.location.reload(); });
            } else {
                confirm(msg['sys_msg'], msg['perform_success'], msg['ok'], msg['ok'], function () { window.location.href = '/admin/Permissionmanager'; return; });
            }
        },
        error: function () {
            confirm(msg['system_error'], msg['system_error_message'], msg['ok'], msg['ok'], function () { window.location.href = '/admin/error'; });
        }
    });
}

