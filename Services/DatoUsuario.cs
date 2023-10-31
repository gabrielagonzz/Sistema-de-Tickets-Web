using Newtonsoft.Json;
using Practica4.Interfaces;
using Practica4.Models;
using System.Xml;

namespace Practica4.Services
{
    public class DatoUsuario
    {
        private const string archivoUsuarios = "usuarios.json"; // Ruta al archivo JSON donde se guardarán los usuarios

        public List<IUsuario> ObtenerUsuario()
        {
            if (File.Exists(archivoUsuarios))
            {
                string json = File.ReadAllText(archivoUsuarios);
                var settings = new JsonSerializerSettings
                {
                    Converters = { new ConvertirUsuarios() }
                };
                return JsonConvert.DeserializeObject<List<IUsuario>>(json, settings);
            }
            else
            {
                return new List<IUsuario>();
            }
        }

        public void GuardarUsuario(List<IUsuario> lista)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = { new ConvertirUsuarios() } // Add the custom converter
            };
            string json = JsonConvert.SerializeObject(lista, Newtonsoft.Json.Formatting.Indented, settings);
            File.WriteAllText(archivoUsuarios, json);
        }

        public void AgregarNuevoUsuario(Usuario nuevoUsuario)
        {
            List<IUsuario> usuarios = ObtenerUsuario();

            // Verifica si el usuario ya existe
            if (usuarios.Any(u => u.Nombre == nuevoUsuario.Nombre))
            {
                throw new Exception("El usuario ya existe.");
            }

            nuevoUsuario.Id = CrearID(usuarios);

            usuarios.Add((IUsuario)nuevoUsuario);

            // Guarda la lista actualizada en el archivo JSON
            GuardarUsuario(usuarios);
        }
        public int CrearID(List<IUsuario> lista)
        {
            if (lista.Any() == false)
            {
                return 1;
            }
            else
            {
                return lista.Max(u => u.Id) + 1;
            }
        }
    }
}
