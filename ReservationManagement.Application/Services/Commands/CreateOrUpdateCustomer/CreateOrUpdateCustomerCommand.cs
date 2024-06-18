using MediatR;

namespace ReservationManagement.Application.Services.Commands.CreateOrUpdateCustomer;

public record CreateOrUpdateCustomerCommand(int Id) : IRequest;