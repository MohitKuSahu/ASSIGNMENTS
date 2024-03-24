using CrudUsingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudUsingCore.DAL
{
    public interface IDAL
    {
        public Task<bool> UpdateEmployeeAsync(EmployeeModel model);
        public Task<bool> DeleteByIdAsync(int EmployeeId);
        public Task<bool> AddEmployeeAsync(EmployeeModel model);
        public Task<List<EmployeeModel>> ListEmployeeAsync();

        public Task<EmployeeModel> GetEmployeeByIdAsync(int EmployeeId);
    }
}
