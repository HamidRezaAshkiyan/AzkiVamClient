using Ardalis.GuardClauses;
using AzkiVamClient.Common;
using AzkiVamClient.Dtos;
using System.Net.Http.Json;

namespace AzkiVamClient;

public interface IAzkiVamClient
{
    Task<AzkiVamSuccessResponse<CancelTicketResponse>> CancelTicketAsync(
        CancelTicketRequest req, CancellationToken cancellationToken = default);
    Task<AzkiVamSuccessResponse<CreateTicketResponse>> CreateTicketAsync(
        CreateTicketRequest req, CancellationToken cancellationToken = default);
    Task<AzkiVamSuccessResponse<ReverseTicketResponse>> ReverseTicketAsync(
        ReverseTicketRequest req, CancellationToken cancellationToken = default);
    Task<AzkiVamSuccessResponse<TicketStatusResponse>> TicketStatusAsync(
        TicketStatusRequest req, CancellationToken cancellationToken = default);
    Task<AzkiVamSuccessResponse<VerifyTicketResponse>> VerifyTicketAsync(
        VerifyTicketRequest req, CancellationToken cancellationToken = default);
}

public class AzkiVamClient : IAzkiVamClient
{
    private readonly HttpClient _httpClient;
    private readonly AzkiVamClientOptions _azkiVamOptions;

    public AzkiVamClient(HttpClient httpClient)
    {
        _azkiVamOptions = new();
        _httpClient = Guard.Against.Null(httpClient);

        _httpClient.BaseAddress = _azkiVamOptions.BaseUrl;
        _httpClient.DefaultRequestHeaders.Add(
            nameof(_azkiVamOptions.MerchantId),
            _azkiVamOptions.MerchantId);
    }

    public async Task<AzkiVamSuccessResponse<CreateTicketResponse>> CreateTicketAsync(
        CreateTicketRequest req,
        CancellationToken cancellationToken = default)
    {
        HttpRequestMessage request = new(
            HttpMethod.Post,
            AzkiVamRoutes.Purchase);

        string encryptedSignature = GetEncryptedSignature(
            AzkiVamRoutes.Purchase, nameof(HttpMethod.Post));

        request.Headers.Add("Signature", encryptedSignature);
        request.Content = req.ToJsonString().ToStringContent();

        var response = await _httpClient.SendAsync(request, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<AzkiVamSuccessResponse<CreateTicketResponse>>(cancellationToken: cancellationToken);
    }

    public async Task<AzkiVamSuccessResponse<CancelTicketResponse>> CancelTicketAsync(
        CancelTicketRequest req,
        CancellationToken cancellationToken = default)
    {
        HttpRequestMessage request = new(
            HttpMethod.Post,
            AzkiVamRoutes.Cancel);

        string encryptedSignature = GetEncryptedSignature(
            AzkiVamRoutes.Cancel, nameof(HttpMethod.Post));

        request.Headers.Add("Signature", encryptedSignature);
        request.Content = req.ToJsonString().ToStringContent();

        var response = await _httpClient.SendAsync(request, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<AzkiVamSuccessResponse<CancelTicketResponse>>(cancellationToken);
    }

    public async Task<AzkiVamSuccessResponse<VerifyTicketResponse>> VerifyTicketAsync(
        VerifyTicketRequest req,
        CancellationToken cancellationToken = default)
    {
        HttpRequestMessage request = new(
            HttpMethod.Post,
            AzkiVamRoutes.Verify);

        string encryptedSignature = GetEncryptedSignature(
            AzkiVamRoutes.Verify, nameof(HttpMethod.Post));

        request.Headers.Add("Signature", encryptedSignature);
        request.Content = req.ToJsonString().ToStringContent();
        var response = await _httpClient.SendAsync(request, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<AzkiVamSuccessResponse<VerifyTicketResponse>>(cancellationToken);
    }

    public async Task<AzkiVamSuccessResponse<TicketStatusResponse>> TicketStatusAsync(
        TicketStatusRequest req,
        CancellationToken cancellationToken = default)
    {
        HttpRequestMessage request = new(
            HttpMethod.Post,
            AzkiVamRoutes.Status);

        string encryptedSignature = GetEncryptedSignature(
            AzkiVamRoutes.Status, nameof(HttpMethod.Post));

        request.Headers.Add("Signature", encryptedSignature);
        request.Content = req.ToJsonString().ToStringContent();
        var response = await _httpClient.SendAsync(request, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<AzkiVamSuccessResponse<TicketStatusResponse>>(cancellationToken);
    }

    public async Task<AzkiVamSuccessResponse<ReverseTicketResponse>> ReverseTicketAsync(
        ReverseTicketRequest req,
        CancellationToken cancellationToken = default)
    {
        HttpRequestMessage request = new(
            HttpMethod.Post,
            AzkiVamRoutes.Reverse);

        string encryptedSignature = GetEncryptedSignature(
            AzkiVamRoutes.Reverse, nameof(HttpMethod.Post));

        request.Headers.Add("Signature", encryptedSignature);
        request.Content = req.ToJsonString().ToStringContent();
        var response = await _httpClient.SendAsync(request, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<AzkiVamSuccessResponse<ReverseTicketResponse>>(cancellationToken);
    }

    private string GetEncryptedSignature(string route, string httpMethod)
    {
        var plainSignature = EncryptionHelper.GeneratePlainSignature(
            route, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), httpMethod, _azkiVamOptions.ApiKey);

        return EncryptionHelper.Encrypt(plainSignature, _azkiVamOptions.ApiKey);
    }
}