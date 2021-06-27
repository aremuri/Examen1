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

    public class GridDepartamentosModel : PageModel
    {
        private readonly IDepartamentoServices departamentoServices;

        public GridDepartamentosModel(IDepartamentoServices departamentoServices)
        {
            this.departamentoServices = departamentoServices;
        }

        public IEnumerable<DepartamentoEntity> GridList { get; set; } = new List<DepartamentoEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult>  OnGet()
        {
            try
            {
                GridList = await departamentoServices.Get();

                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                }

                TempData.Clear();

                return Page();

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnGetEliminar(int id)
        {
            try
            {
                var result = await departamentoServices.Delete(new()
                {
                    Id_Departamento = id
                });

                if (result.CodError!=0)
                {
                    throw new Exception(result.MsgError);  
                }

                TempData["Msg"] = "El registro se elimino Correctamente";

                return Redirect("GridDepartamentos");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }


    }
}
