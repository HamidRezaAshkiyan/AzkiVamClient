using Newtonsoft.Json;

namespace AzkiVamClient.Dtos;

public record ReverseTicketResponse
{
    [JsonProperty("ticket_id")]
    public string TicketId { get; init; }
}