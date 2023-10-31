using Practica4.Interfaces;
using System.Net;
using System.Text;

namespace Practica4.Services
{
    public class EstrategiaEmail : IEstrategia
    {
        private readonly HttpClient _httpClient;
        private string contacto;
        private const string EmailApiUrl = "smtp.gmail.com";

        public EstrategiaEmail(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public EstrategiaEmail(string contacto)
        {
            this.contacto = contacto;
        }

        public async Task EnviarMensajeAsync(string reporte, string usuario)
        {
            var credentials = new NetworkCredential("gabrielagd04@gmail.com", "YokastaGGD1976!");
            var handler = new HttpClientHandler
            {
                Credentials = credentials,
            };
            var httpClient = new HttpClient(handler);

            var mensaje = $"Enviando mensaje a {usuario} a través de su Email: {reporte}";
            var content = new StringContent(mensaje, Encoding.UTF8, "text/plain");

            var response = await _httpClient.PostAsync($"{EmailApiUrl}/sendEmail", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Mensaje enviado exitosamente a través del correo electrónico.");
            }
            else
            {
                Console.WriteLine("Error al enviar el mensaje a través del correo electrónico.");
            }
        }
        public Task EnviarMensaje(IReporte reporte)
        {
            throw new NotImplementedException();
        }
    }
}
