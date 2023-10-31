using Practica4.Interfaces;
using System.Text;

namespace Practica4.Services
{
    public class EstrategiaTelegram : IEstrategia
    {
        private string Contacto { get; set; }
        private string BotToken { get; set; }
        private long ChatId { get; set; } = 70853569;

        public EstrategiaTelegram(string contacto, string botToken, long chatId)
        {
            this.Contacto = contacto;
            this.BotToken = "6822916979:AAHUJdSFjxGxzK4wlF-KiQ7zxYQ4UWE94pU";
            this.ChatId = chatId;
        }

        public EstrategiaTelegram(string contacto)
        {
            Contacto = contacto;
        }

        public async Task<string> Enviar(IReporte ticket)
        {
            try
            {
                string message = $"Ticket: {ticket.Id}\nDescripción: {ticket.Descripcion}";

                using (var usuario = new HttpClient())
                {
                    usuario.BaseAddress = new Uri($"https://api.telegram.org/bot{BotToken}/");

                    var content = new StringContent($"chat_id={ChatId}&text={message}", Encoding.UTF8, "application/x-www-form-urlencoded");

                    HttpResponseMessage response = await usuario.PostAsync("sendMessage", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return "Mensaje enviado con éxito.";
                    }
                    else
                    {
                        return "Error al enviar el mensaje.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error: {ex.Message}";
            }
        }

        Task IEstrategia.EnviarMensaje(IReporte reporte)
        {
            throw new NotImplementedException();
        }
    }
}
