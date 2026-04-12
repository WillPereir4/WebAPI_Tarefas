using System.Text.Json.Serialization;

namespace WebApi_Tarefas.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusEnum
    {
        Pendente,
        Conclúida
    }
}
