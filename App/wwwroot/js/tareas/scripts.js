const form = document.querySelector('#formEliminar')

form.addEventListener('submit', (e) => {

    e.preventDefault()

    Swal.fire({
        title: `¿Estás seguro de que deseas eliminar esta tarea?`,
        icon: 'info',
        showCancelButton: true,
        confirmButtonColor: '#007bff',
        reverseButtons: true,
        confirmButtonText: 'Si!',
        cancelButtonText: '¡No, cancélalo!'
    }).then((result) => {

        if (result.isConfirmed) {
            e.target.submit()
        }

    })
})

