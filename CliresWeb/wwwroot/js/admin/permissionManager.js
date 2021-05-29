createCookie('page', 'permission_detail', 1);

$(document).ready(function () {
    $('#tbodyPermissionManager tr').dblclick(function () {
        var Permissionid = $(this).attr('Permissionid');
        window.open('/admin/PermissionDetail/' + Permissionid, '_self');
    })
});

function SaveChanges() {
    $('#frmUser').submit();
}

function SaveDataUser() {
    var form = $('#frmUser');
    var url = form.attr('action');

    $('#hdfActive').val($('#Active:checked').length);

    $.ajax({
        type: 'POST',
        url: url,
        dataType: 'json',
        data: form.serialize(), // serializes the form's elements.
        success: function (data) {
            if (data.success) {
                window.location.href = '/admin/admin';
            }
            console.log(data); // show response from the php script.
        }
    });
}

function EditUser(userName) {
    if (LstObj != null && LstObj.length > 0) {
        var tempArr = $.grep(LstObj, function (element, index) {
            return (element.userName === userName);
        });
        BindModalUser(tempArr[0]);
    } else {
        BindModalUser(null);
    }
    $('#modal-lg').modal();
}

function BindModalUser(objUser) {
    if (objUser) {
        $('#hdfIsAdd').val(0);
        $('#UserName').prop('readonly', true);
        //$('#UserName').attr('readonly', 'disabled');
        $('#UserName').val(objUser.userName);
        $('#FullName').val(objUser.fullName);
        $('#Email').val(objUser.email);
        $('#OfficeNumber').val(objUser.officeNumber);
        $('#PhoneNumber').val(objUser.phoneNumber);
        $('#Country').val(objUser.country);
        if (objUser.active === 1)
            $('#Active').prop('checked', true);
        else
            $('#Active').prop('checked', false);
        $("[name='PermissionName']").prop('checked', true);
        $("[name='RoleName']").prop('checked', true);
    }
    else {
        $('#hdfIsAdd').val(1);
        $('#UserName').prop('readonly', false);
        //$('#UserName').removeAttr('disabled');
        $('#UserName').val('');
        $('#FullName').val('');
        $('#Email').val('');
        $('#OfficeNumber').val('');
        $('#PhoneNumber').val('');
        $('#Country').val('');
        $('#Active').prop('checked', false);
        $("[name='PermissionName']").prop('checked', false);
        $("[name='RoleName']").prop('checked', false);
    }
}

function AddUser(action) {
    createCookie('page', 'permission_detail', 1);
    window.location.href = '/admin/Permissiondetail';
}