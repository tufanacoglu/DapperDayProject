using Dapper;
using DapperDayProject.Context;
using DapperDayProject.Dtos.CustomerDtos;
using DapperDayProject.Repositories.Abstract;

namespace DapperDayProject.Repositories.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly DapperContext _context;

        public CustomerService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            string query = "insert into TblCustomer (CustomerName,CustomerSurname,CustomerBalance) values (@customerName,@customerSurname,@customerBalance)";
            var parameters = new DynamicParameters();
            parameters.Add("@customerName", createCustomerDto.CustomerName);
            parameters.Add("@customerSurname", createCustomerDto.CustomerSurname);
            parameters.Add("@customerBalance", createCustomerDto.CustomerBalance);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteCustomer(int customerId)
        {
            string query = "Delete From TblCustomer where CustomerId=@customerId";
            var parameters = new DynamicParameters();
            parameters.Add("@customerId", customerId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCustomerDto>> GetAllCustomerAsync()
        {
            string query = "Select * From TblCustomer";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultCustomerDto>(query);
            return values.ToList();
        }

        public async Task<GetCustomerByIdDto> GetCustomerById(int id)
        {
            string query = "Select * From TblCustomer Where CustomerId=@customerId";
            var parameters = new DynamicParameters();
            parameters.Add("@customerId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstAsync<GetCustomerByIdDto>(query, parameters);
            return values;
        }

        public async Task UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            string query = "Update TblCustomer Set CustomerName=@p1,CustomerSurname=@p2,CustomerBalance=@p3 where CustomerId=@p4";
            var parameters = new DynamicParameters();
            parameters.Add("@p1", updateCustomerDto.CustomerName);
            parameters.Add("@p2", updateCustomerDto.CustomerSurname);
            parameters.Add("@p3", updateCustomerDto.CustomerBalance);
            parameters.Add("@p4", updateCustomerDto.CustomerId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
