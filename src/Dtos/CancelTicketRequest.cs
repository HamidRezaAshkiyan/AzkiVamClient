using Newtonsoft.Json;

namespace AzkiVamClient.Dtos;

public record CancelTicketRequest
{
    [JsonProperty("ticket_id")]
    public string TicketId { get; init; }
}
