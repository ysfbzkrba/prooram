using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using prooram.Application.Category.Queries;
using System.Threading.Tasks;

namespace prooram.WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoriesController : Controller
    {
        private ISender _mediatr;

        protected ISender Mediatr => _mediatr ??= HttpContext.RequestServices.GetService<ISender>();

        public async Task<IActionResult> Index()
        {
            var categories = await Mediatr.Send(new GetAllCategoriesQuery());

            return View(categories);
        }
    }
}
