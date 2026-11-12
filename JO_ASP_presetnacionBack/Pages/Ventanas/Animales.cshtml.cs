using JO_lib_presentazionZoo.Interface;
using JO_lib_presentazionZoo.Nucleo;
using Lib_Dominio.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JO_ASP_presetnacionBack.Pages.Ventanas
{
    public class AnimalesModel : PageModel
    {
        private IAnimalesFront IAnimalesFront;

        public AnimalesModel(IAnimalesFront IAnimalesFront)
        {
            this.IAnimalesFront = IAnimalesFront;
            this.Filtro = new Animales();
        }

        public List<Animales>? Lista { get; set; }
        [BindProperty] public Animales? Filtro { get; set; }
        [BindProperty] public Animales? Actual { get; set; }
        public bool Formulario { get; set; } = false;
        public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro!.Nombre = Filtro!.Nombre ?? "";

                if (string.IsNullOrEmpty(Filtro.Nombre) && string.IsNullOrEmpty(Filtro.Codigo))
                    Lista = this.IAnimalesFront.Consultar();
                else
                    Lista = this.IAnimalesFront.Buscar(Filtro);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Formulario = true;
                this.Actual = new Animales();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    this.Actual = this.IAnimalesFront.Insertar(this.Actual!);
                else
                    this.Actual = this.IAnimalesFront.Actualizar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }

        public void OnPostBtEditar(string data)
        {
            try
            {
                Formulario = true;
                OnPostBtConsultar();
                this.Actual = this.Lista!.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtPregBorrar(string data)
        {
            try
            {
                Borrar = true;
                OnPostBtConsultar();
                this.Actual = this.Lista!.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    return;
                this.Actual = this.IAnimalesFront.Borrar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }
    }
}
