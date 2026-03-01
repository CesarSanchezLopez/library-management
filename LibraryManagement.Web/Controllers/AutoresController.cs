using LibraryManagement.Web.Models;
using LibraryManagement.Web.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    public class AutoresController : Controller
    {
        private readonly ApiService _api = new ApiService();

        public async Task<ActionResult> Index()
        {
            var response = await _api.GetAsync("autores");
            var json = await response.Content.ReadAsStringAsync();

            var autores = JsonConvert.DeserializeObject<List<AutorViewModel>>(json);
            return View(autores);
        }

        public async Task<ActionResult> Details(int id)
        {
            var response = await _api.GetAsync($"autores/{id}");
            if (!response.IsSuccessStatusCode)
                return HttpNotFound();

            var json = await response.Content.ReadAsStringAsync();
            var autor = JsonConvert.DeserializeObject<AutorViewModel>(json);
            return View(autor);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AutorViewModel autor)
        {
            if (!ModelState.IsValid)
                return View(autor);

            var response = await _api.PostAsync("autores", autor);
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Autor creado correctamente.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Error al crear el autor.");
            return View(autor);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var response = await _api.GetAsync($"autores/{id}");
            if (!response.IsSuccessStatusCode)
                return HttpNotFound();

            var json = await response.Content.ReadAsStringAsync();
            var autor = JsonConvert.DeserializeObject<AutorViewModel>(json);
            return View(autor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AutorViewModel autor)
        {
            if (!ModelState.IsValid)
                return View(autor);

            var response = await _api.PutAsync($"autores/{id}", autor);
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Autor actualizado correctamente.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Error al actualizar el autor.");
            return View(autor);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var response = await _api.GetAsync($"autores/{id}");
            if (!response.IsSuccessStatusCode)
                return HttpNotFound();

            var json = await response.Content.ReadAsStringAsync();
            var autor = JsonConvert.DeserializeObject<AutorViewModel>(json);
            return View(autor);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var response = await _api.DeleteAsync($"autores/{id}");
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Autor eliminado correctamente.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Error al eliminar el autor.");
            // reload author to show in view
            var getResponse = await _api.GetAsync($"autores/{id}");
            var json = await getResponse.Content.ReadAsStringAsync();
            var autor = JsonConvert.DeserializeObject<AutorViewModel>(json);
            return View(autor);
        }
    }
}