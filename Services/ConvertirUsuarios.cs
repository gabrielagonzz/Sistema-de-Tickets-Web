using Newtonsoft.Json;
using Practica4.Interfaces;

namespace Practica4.Services
{
    public class ConvertirUsuarios : JsonConverter<IUsuario>
    {
        public override IUsuario? ReadJson(JsonReader reader, Type objectType, IUsuario? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, IUsuario? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
