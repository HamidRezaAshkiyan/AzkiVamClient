using Newtonsoft.Json;

namespace AzkiVamClient.Dtos;

public record TicketStatusRequest
{
    [JsonProperty("ticket_id")]
    public string TicketId { get; init; }
}