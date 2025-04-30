namespace MarketPlace.Domain.Enums.Order;

public enum OrderTracingStatus
{
    Processing,
    SendingToStock,
    Packing,
    Posted,
    SendingToDeliveryMan,
    DeliveredToPostman,
    Delivered
}
