using Practica4.Interfaces;
using System.Text;

namespace Practica4.Services
{
    public class EstrategiaWhatsapp : IEstrategia
    {
        private readonly HttpClient _httpClient;
        private string contacto;
        private const string WhatsappApiUrl = ""; // Debo poner la URL de la API de WhatsApp

        public EstrategiaWhatsapp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public EstrategiaWhatsapp(string contacto)
        {
            this.contacto = contacto;
        }

        public async Task EnviarMensajeAsync(string reporte, string usuario)
        {
            var mensaje = $"Enviando mensaje a {usuario} a través de Whatsapp: {reporte}";
            var content = new StringContent(mensaje, Encoding.UTF8, "text/plain");

            var response = await _httpClient.PostAsync($"{WhatsappApiUrl}/sendMessage", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Mensaje enviado exitosamente a través de Whatsapp.");
            }
            else
            {
                Console.WriteLine("Error al enviar el mensaje a través de Whatsapp.");
            }
        }

        public Task EnviarMensaje(IReporte reporte)
        {
            throw new NotImplementedException();
        }
    }
}
