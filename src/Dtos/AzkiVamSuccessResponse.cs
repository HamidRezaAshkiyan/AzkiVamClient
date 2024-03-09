namespace AzkiVamClient.Dtos;

public class AzkiVamSuccessResponse<TResult>
{
    public int RsCode { get; set; }
    public TResult Result { get; set; }
}

public class AzkiVamErrorResponse
{
    public int RsCode { get; set; }
    public string Message { get; set; }
}
