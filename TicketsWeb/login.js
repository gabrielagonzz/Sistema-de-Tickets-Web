document.addEventListener("DOMContentLoaded", function () {
  const loginForm = document.getElementById("login-form");

  loginForm.addEventListener("submit", function (event) {
      event.preventDefault();

      const username = document.getElementById("username").value;
      const password = document.getElementById("password").value;

      const loginData = {
          Nombre: username,
          Contraseña: password,
      };

      fetch("https://localhost:7139/Login/InicioSesion", {
          method: "POST",
          headers: {
              "Content-Type": "application/json",
          },
          body: JSON.stringify(loginData),
      })
          .then((response) => {
              if (!response.ok) {
                  throw new Error("Network response was not ok");
              }
              return response.json();
          })
          .then((responseData) => {
              const role = responseData.rol;
              handleRedirection(role, username);
          })
          .catch((error) => {
              console.error("Error: " + error);
          });
  });

  function handleRedirection(role, username) {
      switch (role) {
          case "Proveedor":
              window.location.href = `../inicioProveedor.html?usuario=${username}`;
              break;
          case "Empleado":
              window.location.href = `../inicioEmpleado.html?usuario=${username}`;
              break;
          case "Cliente":
              window.location.href = `../inicioCliente.html?usuario=${username}`;
              break;
          case "Desconocido":
              alert("Credenciales incorrectas.");
              break;
          default:
              alert("Rol desconocido");
      }
  }
});
