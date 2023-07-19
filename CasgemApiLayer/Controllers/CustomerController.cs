using Casgem.BusinessLayer.Abstract;
using Casgem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Casgem.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult CustomerList()
        {
            var values = _customerService.TGetAll();
            return Ok(values);
        }

        [HttpGet("getbyid")]
        public IActionResult GetCustomer(int id)
        {
            var value = _customerService.TGetById(id);  
            return Ok(value);
        }

        [HttpPost("add")]
        public IActionResult CustomerAdd(Customer customer)
        {
            _customerService.TInsert(customer);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult CustomerUpdate(int id)
        {
            var value = _customerService.TGetById(id);
            _customerService.TUpdate(value);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult CustomerDelete(int id)
        {
            var value = _customerService.TGetById(id);
            _customerService.TDelete(value);
            return Ok();
        }
    }
}
