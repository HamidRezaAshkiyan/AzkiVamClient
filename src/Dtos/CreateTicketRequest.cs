using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AzkiVamClient.Dtos;

public record CreateTicketRequest
{
    [JsonProperty("amount")]
    public int Amount { get; set; }

    [JsonProperty("redirect_uri")]
    public string RedirectUri { get; set; }

    [JsonProperty("fallback_uri")]
    public string FallbackUri { get; set; }

    [JsonProperty("provider_id")]
    public long ProviderId { get; set; }

    [JsonProperty("mobile_number")]
    public string MobileNumber { get; set; }

    [JsonProperty("merchant_id")]
    public string MerchantId { get; set; }

    [JsonProperty("items")]
    public List<CreateTicketRequestItem> Items { get; set; }
}

public record CreateTicketRequestItem
{
    public string Name { get; set; }
    public int Count { get; set; }
    public int Amount { get; set; }
    public string Url { get; set; }
}
