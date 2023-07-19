using Casgem.BusinessLayer.Abstract;
using Casgem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Casgem.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult ProductList() 
        {
            var values = _productService.TGetAll();
            return Ok(values);
        }

        [HttpPost("add")]
        public IActionResult ProductAdd(Product product)
        {
            _productService.TInsert(product);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult ProrductDelete(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok();
        }

        [HttpGet("getbyid")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }

        [HttpPut("update")]
        public IActionResult ProductUpdate(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TUpdate(value);
            return Ok();
        }

        [HttpGet("productlistwithcategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _productService.TGetProductsWithCategories();
            return Ok(values);
        }
    }
}
