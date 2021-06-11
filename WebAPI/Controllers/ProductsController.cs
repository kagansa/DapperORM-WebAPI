using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return Ok(_productService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            int result = _productService.Add(product);
            return result <= 0 ? (IActionResult)BadRequest("HATA: Ürün Eklenirken Hata Oluştu.") : Ok("Ürün Eklendi.");
        }

        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            int result = _productService.Update(product);
            return result <= 0 ? (IActionResult)BadRequest("HATA: Ürün Güncelenirken Hata Oluştu.") : Ok("Ürün Güncellendi.");
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            int result = _productService.Delete(id);
            return result <= 0 ? (IActionResult)BadRequest("HATA: Ürün Silinirken Hata Oluştu.") : Ok("Ürün Silindi.");
        }
    }
}