using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CosmeticApp5.Data;
using CosmeticApp5.Models;
using CosmeticApp5.Services;
using CosmeticApp5.View;


namespace CosmeticApp5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductService _productservice;

        public ProductsController(ProductService productservice)
        {
            _productservice = productservice;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allemployees = _productservice.GetAllEmployees();
            return Ok(allemployees);
        }

        [HttpGet]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _productservice.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] ProductVM employee)
        {
            _productservice.AddEmployee(employee);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateEmployeeById(int id, [FromBody] ProductVM employee)
        {
            var updateEmployee = _productservice.UpdateEmployeeById(id, employee);
            return Ok(updateEmployee);
        }

        [HttpDelete]

        public IActionResult DeleteEmployeeById(int id)
        {
            _productservice.DeleteEmployeeById(id);
            return Ok();
        }
    }

}
