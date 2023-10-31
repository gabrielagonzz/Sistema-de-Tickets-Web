using Practica4.Interfaces;

namespace Practica4.Services
{
    public class Factory
    {
        IEstrategia enviarMensaje;
        public IEstrategia Enviar(int rol, string contacto)
        {
            switch (rol)
            {
                case 1:
                    return enviarMensaje = new EstrategiaWhatsapp(contacto);
                case 2:
                    return enviarMensaje = new EstrategiaTelegram(contacto);
                case 3:
                    return enviarMensaje = new EstrategiaEmail(contacto);

                default:
                    return null;
            }
        }
    }
}
