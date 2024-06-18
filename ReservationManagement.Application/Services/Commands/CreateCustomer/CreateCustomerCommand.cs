using MediatR;

namespace ReservationManagement.Application.Services.Commands.CreateCustomer;

public record CreateCustomerCommand(int Id) : IRequest;