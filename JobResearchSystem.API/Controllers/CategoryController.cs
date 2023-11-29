using JobResearchSystem.Application.Features.Categories.Commands.Models;
using JobResearchSystem.Application.Features.Categories.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobResearchSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await Mediator.Send(new GetAllCategoriesQuery());
            return BaseResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return BaseResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return BaseResult(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(DeleteCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return BaseResult(result);
        }

    }
}
