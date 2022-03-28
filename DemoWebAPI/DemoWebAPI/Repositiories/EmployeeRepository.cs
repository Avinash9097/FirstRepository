using DemoWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPI.Repositiories
{
    public class EmployeeRepository : IEmployeeRepository
    {        
        public readonly EmployeeContext _context;
        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _context = employeeContext;
        }
        public async Task CreateEmployee(Employee employee)
        {
             _context.Employee.Add(employee);
            await _context.SaveChangesAsync();            
        }

        public async Task Delete(int id)
        {
            var getEmpById= await _context.Employee.FindAsync(id);
            _context.Employee.Remove(getEmpById);
            await _context.SaveChangesAsync();
            
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employee.FindAsync(id);            
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task UpdateEmployye(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();            
        }
    }
}
