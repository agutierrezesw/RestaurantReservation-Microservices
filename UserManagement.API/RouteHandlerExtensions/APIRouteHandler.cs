using UserManagement.Application.Services.CustomerServices;

namespace UserManagement.API.RouteHandlerExtensions;

public static class APIRouteHandler
{
    public static void AddMinimalAPIRouteHandlerMappings(this WebApplication app)
    {
        app.MapGet("/customer", (CustomerService service, int customerId) =>
        {
            return service.GetCustomerByIdAsync(customerId);
        })
        .WithName("GetCustomerById")
        .WithOpenApi();

        app.MapPost("/customer", (CustomerService service, NewCustomerRequest request) =>
        {
            return service.CreateCustomerAsync(request);
        })
        .WithName("CreateCustomer")
        .WithOpenApi();

        app.MapDelete("/customer", (CustomerService service, int customerId) =>
        {
            return service.DeleteCustomerAsync(customerId);
        })
        .WithName("DeleteCustomer")
        .WithOpenApi();
    }
}
