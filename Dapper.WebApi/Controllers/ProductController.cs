using Microsoft.AspNetCore.Mvc;

namespace Dapper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region [ Attributes ]

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region [ Constructor ]

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region [ Public Methods ]

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            var data = await _unitOfWork.Products.Get(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> Search() {
            var data = await _unitOfWork.Products.Search();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            var data = await _unitOfWork.Products.Add(product);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var data = await _unitOfWork.Products.Update(product);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) 
        {
            var data = await _unitOfWork.Products.Delete(id);
            return Ok(data);
        }

        #endregion
    }
}