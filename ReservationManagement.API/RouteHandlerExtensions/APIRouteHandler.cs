using ReservationManagement.Application.Services.ReservationService.Requests;
using ReservationManagement.Application.Services.ReservationServices;

namespace ReservationManagement.API.RouteHandlerExtensions;

public static class APIRouteHandler
{
    public static void AddMinimalAPIRouteHandlerMappings(this WebApplication app)
    {
        app.MapGet("/reservation", (ReservationService service, int reservationId) =>
        {
            return service.GetReservationByIdAsync(reservationId);
        })
        .WithName("GetReservationById")
        .WithOpenApi();

        app.MapPost("/reservation", (ReservationService service, NewReservationRequest request) =>
        {
            return service.CreateReservationAsync(request);
        })
        .WithName("CreateReservation")
        .WithOpenApi();

        app.MapDelete("/customer", (ReservationService service, int reservationId) =>
        {
            return service.DeleteReservationAsync(reservationId);
        })
        .WithName("DeleteReservation")
        .WithOpenApi();
    }
}
