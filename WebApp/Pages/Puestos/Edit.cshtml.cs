using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Puestos
{
    public class EditModel : PageModel
    {
        private readonly IPuestosServices puestosServices;

        public EditModel(IPuestosServices puestosServices )
        {
            this.puestosServices = puestosServices;
        }

        [BindProperty]
        public PuestosEntity Entity { get; set; } = new PuestosEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public async Task<IActionResult> OnGet()//llama al metodo 
        {
            try
            {
                if (id.HasValue)//si el id q recibimos tiene valor
                {
                    Entity = await puestosServices.GetById(new() { Id_Puesto = id });
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
                if (Entity.Id_Puesto.HasValue)//si el id q recibimos tiene valor
                {
                    //Actualizar
                    var result = await puestosServices.Update(Entity);
                    if (result.CodError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se actualizo Correctamente";
                }

                else
                {
                    var result = await puestosServices.Create(Entity);
                    if (result.CodError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se Agrego Correctamente";

                }

                return RedirectToPage("GridPuestos");
            }

            catch (Exception ex)
            {
                return Content(ex.Message);
            }


        }
    }
}
