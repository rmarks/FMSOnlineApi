using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Api.Features.CompanyList
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyListController : ControllerBase
    {
        private readonly CompanyListRepository _repo;

        public CompanyListController(CompanyListRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get(string? searchString, int page, int pageSize)
        {
            var model = _repo.GetPagedList(searchString, page, pageSize);

            return Ok(model);
        }
    }
}
