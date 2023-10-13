Swal.fire({
    title: '¡Bienvenido!',
    text: 'Te invito a que autentiques tu usuario!',
    icon: 'info',
    confirmButtonText: 'Aceptar'
});

const urlAuth = "http://localhost:5107/User/loguear";
const headers = new Headers({ 'Content-Type': 'application/json' });
const boton = document.getElementById('boton');

boton.addEventListener("click", function (e) {
    e.preventDefault();
    autorizarUsuario();
});

async function autorizarUsuario() {
    let inputUser = document.getElementById('username').value;
    let inputPassword = document.getElementById('password').value;

    let data = {
        "username": inputUser,
        "password": inputPassword
    }

    const config = {
        method: 'POST',
        headers: headers,
        body: JSON.stringify(data)
    };

    try {
        const response = await fetch(urlAuth, config);

        if (response.ok) {
            Swal.fire({
                title: '¡Autenticacion exitosa!',
                text: 'Tu autenticacion ha sido valida!',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location.href = "http://localhost:5107/swagger";
                }
            });
        } else {
            alert("Autenticacion fallida! Verifique sus credenciales o registrese!");
        }
    } catch (error) {
        console.error("Error al realizar la Autenticacion:", error);
    }
}