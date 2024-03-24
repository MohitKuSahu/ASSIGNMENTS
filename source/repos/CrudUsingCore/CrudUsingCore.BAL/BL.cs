using CrudUsingCore.DAL;
using CrudUsingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudUsingCore.BL
{
    public class BL:IBL
    {
        private IDAL _dataAccess;

        public BL(IDAL dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeModel model)
        {
            return await _dataAccess.UpdateEmployeeAsync(model);
        }

        public async Task<bool> DeleteByIdAsync(int EmployeeId)
        {
            return await _dataAccess.DeleteByIdAsync(EmployeeId);
        }

        public async Task<bool> AddEmployeeAsync(EmployeeModel model)
        {
            return await _dataAccess.AddEmployeeAsync(model);
        }

        public async Task<List<EmployeeModel>> ListEmployeeAsync()
        {
            return await _dataAccess.ListEmployeeAsync();
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int EmployeeId)
        {
            return await _dataAccess.GetEmployeeByIdAsync(EmployeeId);
        }
    }
}
