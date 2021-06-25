var Toast = Swal.mixin({
    toast: true,
    position: 'center',
    showConfirmButton: false,
    timer: 3000
})

function showAlert(type, message) {
    Toast.fire({
        icon: type,
        title: message
    })
}

