using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudUsingCore.Models;
using CrudUsingCore.DAL;

namespace CrudUsingCore.BL
{
    public interface IBL
    {
        Task<bool> UpdateEmployeeAsync(EmployeeModel model);
        Task<bool> DeleteByIdAsync(int EmployeeId);
        Task<bool> AddEmployeeAsync(EmployeeModel model);
        Task<List<EmployeeModel>> ListEmployeeAsync();
        Task<EmployeeModel> GetEmployeeByIdAsync(int EmployeeId);
    }
}
