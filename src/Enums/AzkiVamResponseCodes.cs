namespace AzkiVamClient.Enums;

enum AzkiVamResponseCodes
{
    RequestFinishedSuccessfully = 0,
    InternalServerError = 1,
    ResourceNotFound = 2,
    MalformedData = 4,
    DataNotFound = 5,
    AccessDenied = 15,
    TransactionAlreadyReversed = 16,
    TicketExpired = 17,
    SignatureInvalid = 18,
    TicketUnpayable = 19,
    TicketCustomerMismatch = 20,
    InsufficientCredit = 21,
    UnverifiableTicketDueToStatus = 28,
    InvalidInvoiceData = 32,
    ContractNotStarted = 33,
    ContractExpired = 34,
    ValidationException = 44,
    RequestDataNotValid = 51,
    TransactionNotReversible = 59,
    TransactionMustBeInVerifiedState = 60
}
