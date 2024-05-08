using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProyectoP1.Permisos
{
    public class ValidarSesionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filtercontext)
        {
            if (filtercontext.HttpContext.Session.GetString("usuario") == null)
            {
                filtercontext.Result = new RedirectResult("~/Acceso/Login");
            }
            base.OnActionExecuting(filtercontext);
        }
    }
}
