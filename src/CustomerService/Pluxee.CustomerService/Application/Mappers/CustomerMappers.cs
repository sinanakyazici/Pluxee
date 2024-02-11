using AutoMapper;
using Pluxee.CustomerService.Application.Commands.CustomerCommands.CreateCustomer;
using Pluxee.CustomerService.Domain.Customer;

namespace Pluxee.CustomerService.Application.Mappers;

public class CustomerMappers : Profile
{
    public CustomerMappers()
    {
        CreateMap<CreateCustomerCommand, Customer>();
    }
}