using Newtonsoft.Json;

namespace AzkiVamClient.Dtos;

public record ReverseTicketRequest
{
    [JsonProperty("provider_id")]
    public string ProviderId { get; init; }

    [JsonProperty("ticket_id")]
    public string TicketId { get; init; }
}
