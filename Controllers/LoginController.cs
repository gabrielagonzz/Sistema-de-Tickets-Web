using Microsoft.AspNetCore.Mvc;
using Practica4.Models;
using Practica4.Services;

namespace Practica4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {

        DatoUsuario datoUsuario = new DatoUsuario();

        public ActionResult Index()
        {
            // Vista de inicio de sesión
            return View();
        }

        [HttpPost]
        public ActionResult Login(string usuario, string password)
        {
            Login login = new Login();
            int rol = login.LoginStart(usuario, password);

            if (rol == 0)
            {
                ViewBag.ErrorMessage = "Usuario o contraseña incorrectos.";
                return View("Index");
            }
            else
            {
                return RedirectToAction("Dashboard", new { rol });
            }
        }

        public ActionResult Dashboard(int rol)
        {
            ViewBag.Role = GetRoleName(rol);

            // Implementamos diferentes vistas basadas en el rol del usuario
            return View();
        }

        private string GetRoleName(int rol)
        {
            // Asociamos el ID de rol con el nombre del rol
            switch (rol)
            {
                case 1:
                    return "Proveedor";
                case 2:
                    return "Empleado";
                case 3:
                    return "Cliente";
                default:
                    return "Desconocido";
            }
        }
        public ActionResult AgregarProveedorGabriela()
        {
            Usuario nuevoUsuario = new Usuario
            {
                Nombre = "Gabriela",
                Contraseña = "1234",
                Rol = 1 // 1 representa un proveedor
            };

            try
            {
                datoUsuario.AgregarNuevoUsuario(nuevoUsuario);
                ViewBag.SuccessMessage = "Usuario proveedor Gabriela agregado correctamente.";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View("Index");
        }
    }
}
