using Newtonsoft.Json;

namespace AzkiVamClient.Dtos;

public record VerifyTicketRequest
{
    [JsonProperty("ticket_id")]
    public string TicketId { get; init; }
}
