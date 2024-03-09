using Newtonsoft.Json;

namespace AzkiVamClient.Dtos;

public record VerifyTicketResponse
{
    [JsonProperty("payment_uri")]
    public string PaymentUri { get; init; }

    [JsonProperty("ticket_id")]
    public string TicketId { get; init; }
}
