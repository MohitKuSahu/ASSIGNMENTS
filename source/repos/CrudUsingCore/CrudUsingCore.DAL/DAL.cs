using CrudUsingCore.DAL.Models;
using CrudUsingCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudUsingCore.DAL
{
    public class DAL : IDAL
    {
        private readonly EmployeelistContext _employeelistContext;

        public DAL(EmployeelistContext employeelistContext)
        {
            this._employeelistContext = employeelistContext;
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeModel model)
        {
            var employeeToUpdate = await _employeelistContext.EmployeeesLists.FirstOrDefaultAsync(stu => stu.EmployeeId == model.EmployeeId);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Name = model.Name;
                employeeToUpdate.Email = model.Email;
                employeeToUpdate.TechStack = model.TechStack;
                await _employeelistContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteByIdAsync(int EmployeeId)
        {
            var EmployeeToUpdate = await _employeelistContext.EmployeeesLists.FirstOrDefaultAsync(stu => stu.EmployeeId == EmployeeId);
            if (EmployeeToUpdate != null)
            {
                _employeelistContext.EmployeeesLists.Remove(EmployeeToUpdate);
                await _employeelistContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> AddEmployeeAsync(EmployeeModel model)
        {
            var newEmployee = new EmployeeesList()
            {
                Email = model.Email,
                Name = model.Name,
                TechStack = model.TechStack,

            };
            _employeelistContext.EmployeeesLists.Add(newEmployee);
            await _employeelistContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<EmployeeModel>> ListEmployeeAsync()
        {
            List<EmployeeModel> alldata = new List<EmployeeModel>();
            var result = await _employeelistContext.EmployeeesLists.ToListAsync();
            if (result.Count > 0)
            {
                foreach (var employee in result)
                {
                    alldata.Add(new EmployeeModel { Name = employee.Name, Email = employee.Email, TechStack = employee.TechStack, EmployeeId = employee.EmployeeId });
                }
            }
            return alldata;
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int EmployeeId)
        {
            var employee = await _employeelistContext.EmployeeesLists.FirstOrDefaultAsync(stu => stu.EmployeeId == EmployeeId);
            if (employee != null)
            {
                return new EmployeeModel
                {
                    EmployeeId = EmployeeId,
                    Name = employee.Name,
                    TechStack = employee.TechStack,
                    Email = employee.Email,
                };
            }
            return null;
        }
    }
}
