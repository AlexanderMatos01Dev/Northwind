using Microsoft.AspNetCore.Mvc;
using Northwind.Customers.Application.Contracts; // Cambiado a Customers
using Northwind.Customer.Application.Dto;

namespace Northwind.Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("GetCustomers")]
        public IActionResult Get()
        {
            var result = this.customerService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("GetCustomerById/{id}")]
        public IActionResult Get(string id)
        {
            var result = this.customerService.GetById(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPost("SaveCustomer")]
        public IActionResult Post(CustomerDtoSave customerDtoSave)
        {
            var result = this.customerService.Add(customerDtoSave);
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtAction(nameof(Get), new { id = customerDtoSave.CustomerId }, result);
        }

        [HttpPut("UpdateCustomer")]
        public IActionResult Put(CustomerDtoUpdate customerDtoUpdate)
        {
            var result = this.customerService.Update(customerDtoUpdate);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("RemoveCustomer/{id}")]
        public IActionResult Delete(string id)
        {
            var result = this.customerService.Remove(new CustomerDtoRemove { CustomerId = id });
            if (!result.Success)
                return BadRequest(result);
            return NoContent();
        }
    }
}
