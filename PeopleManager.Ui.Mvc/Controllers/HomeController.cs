using Microsoft.AspNetCore.Mvc;
using PeopleManager.Ui.Mvc.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PeopleManager.Ui.Mvc.Core;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly PeopleManagerDbContext _peopleManagerDbContext;

        public HomeController(PeopleManagerDbContext peopleManagerDbContext)
        {
            _peopleManagerDbContext = peopleManagerDbContext;
        }

        public IActionResult Index()
        {
            // zolang op DbContext geen ToList = gewoon een intentie/vraag MAAR DOET IE NIETS !!!
            // dus toList zal zorgen dat er van de beschrijving lijst een echte lijst wordt gemaakt die view 
            var people = _peopleManagerDbContext.People.ToList();
            return View(people);
        }

        /*public IActionResult Details(int id)
        {
            // geef voor elke persoon in de lijst de persoon met het gevraagd Id terug
            var person = _peopleManagerDbContext.People.FirstOrDefault(person => person.Id == id);
            if (person is null)
            {
                // als er iets misloopt terug naar index pagina
                return RedirectToAction("Index");
            }

            // Nog een view bijmaken
           return View(person);
        }*/


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
