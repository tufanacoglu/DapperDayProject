using DapperDayProject.Dtos.CustomerDtos;

namespace DapperDayProject.Repositories.Abstract
{
    public interface ICustomerService
    {
        Task<List<ResultCustomerDto>> GetAllCustomerAsync();
        Task CreateCustomer(CreateCustomerDto createCustomerDto);
        Task UpdateCustomer(UpdateCustomerDto updateCustomerDto);
        Task DeleteCustomer(int customerId);
        Task<GetCustomerByIdDto> GetCustomerById(int id);
    }
}
