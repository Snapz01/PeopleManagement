using Microsoft.AspNetCore.Mvc;
using PeopleManagement2.Models;

namespace PeopleManagement2.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public IActionResult Index(string searchString)
        {
            var people = string.IsNullOrEmpty(searchString)
                ? _peopleService.All()
                : _peopleService.Search(searchString);

            var viewModel = new PeopleViewModel
            {
                People = people,
                SearchString = searchString
            };

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var person = _peopleService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public IActionResult Edit(int id)
        {
            var person = _peopleService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }

            var viewModel = new CreatePersonViewModel
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                CityName = person.CityName
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                var result = _peopleService.Edit(id, person);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            return View(person);
        }

        public IActionResult Delete(int id)
        {
            var person = _peopleService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _peopleService.Remove(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
