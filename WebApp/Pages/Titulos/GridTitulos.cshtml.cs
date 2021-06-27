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
    public class GridTitulosModel : PageModel
    {
        private readonly ITituloServices tituloServices;

        public GridTitulosModel(ITituloServices tituloServices)
        {
            this.tituloServices = tituloServices;
        }

        public IEnumerable<TitulosEntity> GridList { get; set; } = new List<TitulosEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await tituloServices.Get();

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
                var result = await tituloServices.Delete(new()
                {
                    Id_Titulo = id
                });

                if (result.CodError != 0)
                {
                    throw new Exception(result.MsgError);
                }

                TempData["Msg"] = "El Registro se elimino Correctamente";

                return Redirect("GridTitulos");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }
    }
}
