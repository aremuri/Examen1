using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Titulos
{
    public class EditModel : PageModel
    {
        private readonly ITituloServices tituloServices;

        public EditModel(ITituloServices tituloServices)
        {
            this.tituloServices = tituloServices;
        }

        [BindProperty]
        public TitulosEntity Entity { get; set; } = new TitulosEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public async Task<IActionResult> OnGet()//llama al metodo 
        {
            try
            {
                if (id.HasValue)//si el id q recibimos tiene valor
                {
                    Entity = await tituloServices.GetById(new() { Id_Titulo = id });
                }

                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }


        }

        public async Task<IActionResult> OnPostAsync()//llama al metodo 
        {
            try
            {
                if (Entity.Id_Titulo.HasValue)//si el id q recibimos tiene valor
                {
                    //Actualizar
                    var result = await tituloServices.Update(Entity);
                    if (result.CodError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se actualizo Correctamente";
                }

                else
                {
                    var result = await tituloServices.Create(Entity);
                    if (result.CodError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se Agrego Correctamente";

                }

                return RedirectToPage("GridTitulos");
            }

            catch (Exception ex)
            {
                return Content(ex.Message);
            }


        }
    }
}
