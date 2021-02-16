using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using prooram.Application.CategoryMediatr.Commands;
using prooram.Application.CategoryMediatr.Queries;
using prooram.Application.CategoryMediatr.Validators;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace prooram.WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoriesController : Controller
    {
        private ISender _mediatr;

        protected ISender Mediatr => _mediatr ??= HttpContext.RequestServices.GetService<ISender>();

        #region Index
        public async Task<IActionResult> Index()
        {
            var categories = await Mediatr.Send(new GetAllCategoriesQuery());

            return View(categories);
        } 
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            //var validator = new CreateCategoryValidator();
            //var result = await validator.ValidateAsync(command);

            //if (result.IsValid)
            //{
            //    await Mediatr.Send(command);
            //    return RedirectToAction(actionName: nameof(Index));
            //}
            //var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();

            //ModelState.AddModelError("CategoryName", string.Join(",", errors));

            try
            {
                await Mediatr.Send(command);
                return RedirectToAction(actionName: nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("CategoryName", ex.Message);

                return View();
            }
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await Mediatr.Send(new GetCategoryQuery() { Id = id });

            return View(result);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateCategoryCommand command)
        {
            var validator = new UpdateCategoryValidator();
            var result = await validator.ValidateAsync(command);
            if (result.IsValid)
            {
                await Mediatr.Send(command);
                return View();
            }

            var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
            ModelState.AddModelError("CategoryName", string.Join(",", errors));
            return View();
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id.HasValue)
            {
                await Mediatr.Send(new DeleteCategoryCommand() { Id = id.Value });
                return RedirectToAction(actionName: nameof(Index));
            }

            return NotFound();

        }
        #endregion

        #region Details
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await Mediatr.Send(new DetailsCategoryQuery() { Id = id });

            return View(result);
        } 
        #endregion


    }
}
