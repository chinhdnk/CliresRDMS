createCookie('page', 'login', 1);
$(document).ready(function () {
    bindEvents();
    bindCountries();
    bindProjects();
    $.validator.setDefaults({
        submitHandler: function () {
            signUp();
        }
    });

    $('#formSignUp').validate({
        rules: {
            fullname: {
                required: true,
                maxlength: 30
            },
            email: {
                required: true,                
            },
            mphone: {
                maxlength: 12
            },
            ophone: {
                maxlength: 12
            },
            agreeTerms: {
                required: true
            }
        },
        messages: {
            fullname: {
                required: msgValidate['full_name_required'],
                maxlength: msgValidate['fullname_maximum']
            },
            email: {
                required: msgValidate['email_required'],
                email: msgValidate['email_invalid'],
            },
            mphone: {                
                maxlength: msgValidate['phone_maximum']
            },
            ophone: {
                maxlength: msgValidate['phone_maximum']
            },
            agreeTerms: msgValidate['clires_rules_required']
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

function bindEvents() {
    $('#email').focus(function () {
        $("span[id='email-existed']").remove();
        $(this).removeClass('is-invalid');
    });
}

function bindCountries() {
    $.ajax({
        type: 'GET',
        url: 'GetCountries',
        dataType: 'json',
        data: {lang : 'en'},
        success: function (result) {           
            if (result.statusCode === 200) {    
                for (key in result.countries) {                   
                    $('#country').append($('<option></option>').val(key).html(result.countries[key]));                    
                }               

                $('#country').select2({
                    theme: 'bootstrap4',
                    placeholder: 'Select a country',
                    allowClear: true
                });

            } else {
                window.location.href = '/home/error';
            }            
        },
        error: function () {            
            window.location.href = '/home/error';
        }
    });
}

function bindProjects() {
    $('#regproject').select2({
        theme: 'bootstrap4'
    });
}

function signUp() {
    $('#formLoading').show();
    var form = $('#formSignUp');
    var url = form.attr('action');    
    $.ajax({
        type: 'POST',
        url: url,
        dataType: 'json',
        data: form.serialize(),
        success: function (result) {
            $('#formLoading').hide();
            if (result.statusCode === 200) {
                if (result.existCode === 1) {
                    $('#formLoading').hide();
                    showEmailExistedError();
                } else if (result.existCode === 0) {
                    $('#compleSignUpModal').modal('show');
                    resetSignUpForm();
                } 
            } else {
                window.location.href = '/admin/error';
            }            
        },
        error: function () {
            window.location.hreft = '/admin/error';
        }
    });
}

function resetSignUpForm() {
    $('#formSignUp')[0].reset();
    $('#country').empty();
    $('#regproject').empty();
}

function showEmailExistedError() {
    var spanElement = $("span[id='email-existed']");
    if ($(spanElement).length <= 0) {
        var errorElement = $("<span id='email-existed'></span>").addClass('invalid-feedback').attr('data-error', 'email-existed').text('This email is used by someone');
        $('#email').closest('.form-group').append(errorElement);
        
    } else {
        $(spanElement).css('display', 'block');
    }
    $('#email').addClass('is-invalid');
}

