using LibraryManagement.Web.Models;
using LibraryManagement.Web.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApiService _api = new ApiService();

        public async Task<ActionResult> Index()
        {
            var response = await _api.GetAsync("libros");
            var json = await response.Content.ReadAsStringAsync();

            var libros = JsonConvert.DeserializeObject<List<LibroViewModel>>(json);
            return View(libros);
        }

        public async Task<ActionResult> Details(int id)
        {
            var response = await _api.GetAsync($"libros/{id}");
            if (!response.IsSuccessStatusCode)
                return HttpNotFound();

            var json = await response.Content.ReadAsStringAsync();
            var libro = JsonConvert.DeserializeObject<LibroViewModel>(json);
            return View(libro);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LibroViewModel libro)
        {
            if (!ModelState.IsValid)
                return View(libro);

            var response = await _api.PostAsync("libros", libro);
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Libro creado correctamente.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Error al crear el libro.");
            return View(libro);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var response = await _api.GetAsync($"libros/{id}");
            if (!response.IsSuccessStatusCode)
                return HttpNotFound();

            var json = await response.Content.ReadAsStringAsync();
            var libro = JsonConvert.DeserializeObject<LibroViewModel>(json);
            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LibroViewModel libro)
        {
            if (!ModelState.IsValid)
                return View(libro);

            var response = await _api.PutAsync($"libros/{id}", libro);
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Libro actualizado correctamente.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Error al actualizar el libro.");
            return View(libro);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var response = await _api.GetAsync($"libros/{id}");
            if (!response.IsSuccessStatusCode)
                return HttpNotFound();

            var json = await response.Content.ReadAsStringAsync();
            var libro = JsonConvert.DeserializeObject<LibroViewModel>(json);
            return View(libro);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var response = await _api.DeleteAsync($"libros/{id}");
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Libro eliminado correctamente.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Error al eliminar el libro.");
            var getResponse = await _api.GetAsync($"libros/{id}");
            var json = await getResponse.Content.ReadAsStringAsync();
            var libro = JsonConvert.DeserializeObject<LibroViewModel>(json);
            return View(libro);
        }
    }
}
