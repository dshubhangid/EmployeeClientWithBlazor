using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeClientWithBlazor.Services
{
    public interface IEmployeeService<T>
    {
        Task<T[]> GetAllEmployeeAsync(string requestUri);
        Task<T> GetEmployeeByIdAsync(string requestUri, int Id);
        Task<bool> SaveEmployeeAsync(string requestUri, T obj);
        Task<bool> UpdateEmployeeAsync(string requestUri, int Id, T obj);
        Task<bool> DeleteEmployeeAsync(string requestUri, int Id);
    }
}
