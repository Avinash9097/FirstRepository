using DemoWebAPI.Models;
using DemoWebAPI.Repositiories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public readonly IEmployeeRepository _employeeRepoistory;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepoistory = employeeRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepoistory.GetEmployees();
        }
        [HttpGet("{id}")]
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeRepoistory.GetEmployeeById(id);
        }
        [HttpPost]
        public async Task CreateEmployee(Employee employee)
        {
             await _employeeRepoistory.CreateEmployee(employee);
        }
        [HttpPut]
        public async Task UpdateEmployee([FromBody] Employee employee)
        {
            await _employeeRepoistory.UpdateEmployye(employee);
        }
        [HttpDelete("{Id}")]
        public async Task DeleteEmployee(int Id)
        {
            await _employeeRepoistory.Delete(Id);
        }
    }
}
