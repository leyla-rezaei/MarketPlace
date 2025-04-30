namespace MarketPlace.Domain.Enums.Order;

public enum OrderStatus
{
    Cancelled,
    PendingPayment,
    Processing,
    OnHold,
    Completed,
    Refunded,
    Failed
}
