using Dapper;
using Para.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Para.Data.DapperRepository
{
    public class CustomerReadOnlyRepository : ICustomerReadOnlyRepository
    {
        private readonly IDbConnection _dbConnection;

        public CustomerReadOnlyRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Customer>> GetCustomersWithDetails()
        {
            var sql = @"
            SELECT * FROM dbo.Customer c
            LEFT JOIN dbo.CustomerDetail cd ON c.Id = cd.CustomerId
            LEFT JOIN dbo.CustomerAddress ca ON c.Id = ca.CustomerId
            LEFT JOIN dbo.CustomerPhone cp ON c.Id = cp.CustomerId";

            var customerDict = new Dictionary<long, Customer>();

            var customers = await _dbConnection.QueryAsync<Customer, CustomerDetail, CustomerAddress, CustomerPhone, Customer>(
                sql,
                (customer, detail, address, phone) =>
                {
                    if (!customerDict.TryGetValue(customer.Id, out var currentCustomer))
                    {
                        currentCustomer = customer;
                        currentCustomer.CustomerDetail = detail;
                        currentCustomer.CustomerAddresses = new List<CustomerAddress>();
                        currentCustomer.CustomerPhones = new List<CustomerPhone>();
                        customerDict[customer.Id] = currentCustomer;
                    }

                    if (address != null && !currentCustomer.CustomerAddresses.Contains(address))
                    {
                        currentCustomer.CustomerAddresses.Add(address);
                    }

                    if (phone != null && !currentCustomer.CustomerPhones.Contains(phone))
                    {
                        currentCustomer.CustomerPhones.Add(phone);
                    }

                    return currentCustomer;
                },
                splitOn: "Id,CustomerId,CustomerId,CustomerId");

            return customers.Distinct().ToList();
        }
    }

}
