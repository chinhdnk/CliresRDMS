createCookie('page', 'user_detail', 1);

$(document).ready(function () {
    $.validator.setDefaults({
        submitHandler: function () {
            SaveDataUser();
        }
    });
    $('#frmUser').validate({
        rules: {
            UserName: {
                required: true,
            },
            FullName: {
                required: true,
            },
            Email: {
                required: true,
                email: true,
            },
            password: {
                required: true,
                minlength: 8
            },
            terms: {
                required: true
            },
        },
        messages: {
            UserName: {
                required: 'Please enter Username',
            },
            FullName: {
                required: 'Please enter full name',
            },
            Email: {
                required: 'Please enter a email address',
                email: 'Please enter a vaild email address'
            },
            password: {
                required: 'Please provide a password',
                minlength: 'Your password must be at least 6 characters long'
            },
            terms: 'Please accept our terms'
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

    $('#tbodyUserManager tr').dblclick(function () {
        createCookie('page', 'user_detail', 1);
        var username = $(this).attr('username');
        window.open('/admin/userdetail/' + username, '_self');
    })

    $('#tbodySignUp tr').dblclick(function () {
        var username = $(this).attr('username');
        var email = $(this).attr('email');
        createCookie('page', 'user_detail', 1);
        window.open('/admin/userdetail?id=' + username + '&email=' + email, '_self');
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
    createCookie('page', 'user_detail', 1);
    window.location.href = '/admin/userdetail';
}