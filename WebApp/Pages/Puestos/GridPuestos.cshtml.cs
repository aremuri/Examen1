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
    public class GridPuestosModel : PageModel
    {
        private readonly IPuestosServices puestosServices;

        public GridPuestosModel(IPuestosServices puestosServices)
        {
            this.puestosServices = puestosServices;
        }

        public IEnumerable<PuestosEntity> GridList { get; set; } = new List<PuestosEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await puestosServices.Get();

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
                var result = await puestosServices.Delete(new()
                {
                    Id_Puesto = id
                });

                if (result.CodError != 0)
                {
                    throw new Exception(result.MsgError);
                }

                TempData["Msg"] = "El Puesto se elimino Correctamente";

                return Redirect("GridPuestos");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }
    }
}
