document.addEventListener("DOMContentLoaded", function () {
  // Obtener elementos del formulario
  const form = document.querySelector("form");
  const nombreInput = document.getElementById("nombre");
  const descripcionInput = document.getElementById("descripcion");
  const emailInput = document.getElementById("emailInput");
  const telegramInput = document.getElementById("telegramInput");
  const whatsappInput = document.getElementById("whatsappInput");
  const emailInstrucciones = document.getElementById("emailInstrucciones");
  const telegramInstrucciones = document.getElementById("telegramInstrucciones");
  const whatsappInstrucciones = document.getElementById("whatsappInstrucciones");

  // Manejar la visibilidad de las instrucciones de verificación
  const verificacionCheckboxes = document.querySelectorAll('input[name="verificacion"]');
  verificacionCheckboxes.forEach(function (checkbox) {
    checkbox.addEventListener("change", function () {
      if (checkbox.value === "Email") {
        emailInstrucciones.style.display = checkbox.checked ? "block" : "none";
      } else if (checkbox.value === "Telegram") {
        telegramInstrucciones.style.display = checkbox.checked ? "block" : "none";
      } else if (checkbox.value === "Whatsapp") {
        whatsappInstrucciones.style.display = checkbox.checked ? "block" : "none";
      }
    });
  });

  form.addEventListener("submit", function (event) {
    event.preventDefault(); 

    const nombre = nombreInput.value;
    const descripcion = descripcionInput.value;
    const email = emailInput.value;
    const telegram = telegramInput.value;
    const whatsapp = whatsappInput.value;
    const categorias = Array.from(document.querySelectorAll('input[name="categoria"]:checked')).map(function (checkbox) {
      return checkbox.value;
    });

    if (categorias.length === 0) {
      alert("Por favor, seleccione al menos una categoría.");
      return;
    }

    const data = {
      nombre,
      descripcion,
      categorias,
    };

    if (emailInstrucciones.style.display === "block") {
      data.verificacion = "Email";
      data.email = email;
    } else if (telegramInstrucciones.style.display === "block") {
      data.verificacion = "Telegram";
      data.telegram = telegram;
    } else if (whatsappInstrucciones.style.display === "block") {
      data.verificacion = "Whatsapp";
      data.whatsapp = whatsapp;
    } else {
      alert("Por favor, seleccione una forma de verificación.");
      return;
    }

    fetch("https://localhost:7139/Envio/Email", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    })
      .then(function (response) {
        if (response.ok) {
          alert("Correo electrónico enviado con éxito");
        } else {
          alert("Error al enviar el correo electrónico");
        }
      })
      .catch(function (error) {
        console.error(error);
        alert("Error en la solicitud");
      });
  });
});
