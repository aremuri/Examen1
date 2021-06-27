using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Departamentos
{
    public class EditModel : PageModel
    {
        private readonly IDepartamentoServices departamentoServices;

        public EditModel(IDepartamentoServices departamentoServices)
        {
            this.departamentoServices = departamentoServices;
        }

        [BindProperty]
        public DepartamentoEntity Entity { get; set; } = new DepartamentoEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()//llama al metodo 
        {
            try
            {
                if (id.HasValue)//si el id q recibimos tiene valor
                {
                    Entity = await departamentoServices.GetById(new() { Id_Departamento = id });
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
                if (Entity.Id_Departamento.HasValue)//si el id q recibimos tiene valor
                {
                    //Actualizar
                    var result = await departamentoServices.Update(Entity);
                    if (result.CodError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se actualizo Correctamente";
                }

                else {
                    var result = await departamentoServices.Create(Entity);
                    if (result.CodError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se Agrego Correctamente";

                }

                return RedirectToPage("GridDepartamentos");
            }

            catch (Exception ex)
            {
                return Content(ex.Message);
            }


        }
    }
}
