using AutoMapper;
using AVB.JwtProje.BusinessLayer.Interfaces;
using AVB.JwtProje.Entities.Concrete;
using AVB.JwtProje.Entities.Dtos.ProductDtos;
using AVB.JwtProje.WebApi.CustomFilters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AVB.JwtProje.BusinessLayer.StringInfos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;

namespace AVB.JwtProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = RoleInfo.Admin+ "," + RoleInfo.Member)]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();

            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = RoleInfo.Admin)]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _productService.GetById(id);

            return Ok(products);
        }

        [HttpPost]
        [Authorize(Roles = RoleInfo.Admin)]
        [ValidModel]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductAddDto productAddDto)
        {
            var product = _mapper.Map<Product>(productAddDto);
            await _productService.Add(product);

            return Created("", productAddDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleInfo.Admin)]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateDto productUpdateDto)
        {
            var product = _mapper.Map<Product>(productUpdateDto);
            await _productService.Update(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = RoleInfo.Admin)]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.Remove(new Product() { Id = id });

            return NoContent();
        }


        [Route("/error")]
        public IActionResult Error()
        {
            var errorInfo =HttpContext.Features.Get<IExceptionHandlerPathFeature>();

                        //loglamayı burda yapabiliriz


            return Problem($"apide bir hata oluştu, en kısa zamanda düzeltilecek.. konum : {errorInfo.Path}");

        }

    }
}