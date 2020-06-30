using AVB.JwtProje.BusinessLayer.Interfaces;
using AVB.JwtProje.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace AVB.JwtProje.WebApi.CustomFilters
{
    public class ValidId<TEntity> : IActionFilter where TEntity : class, ITable, new()
    {
        private readonly IGenericService<TEntity> _genericService;

        public ValidId(IGenericService<TEntity> genericService)
        {
            _genericService = genericService;
        }

        // action başladıktan sonra
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        // action başlamadan önce
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.FirstOrDefault(x => x.Key == "id");

            var checkedId = (int)dictionary.Value;

            var entity = _genericService.GetById(checkedId).Result;

            if (entity == null)
            {
                context.Result = new NotFoundObjectResult($"{checkedId} idli nesne bulunamadı");
            }
        }
    }
}