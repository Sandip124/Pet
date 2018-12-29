using System;
using Microsoft.AspNetCore.Mvc;
using Pet.Data;
using Pet.Models;
using Pet.Repository;

namespace Pet.Controllers
{
    public class AnimalController : Controller
    {
        private ApplicationDbContext _context;
        private AnimalRepository _animalRepository;

        public AnimalController(ApplicationDbContext context)
        {
            _context = context;
            _animalRepository = new AnimalRepository(_context);
        }
        public IActionResult Index()
        {
            var animal = _animalRepository.GetAllAnimals();
            return View(animal);
        }

        public IActionResult Details(int id)
        {
            var animal = _animalRepository.GetSingleAnimal(id);
            return View(animal);
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewBag.IsEditMode = "FALSE";
            var animal = new Animal();
            return View(animal);
        }

        [HttpPost]
        public IActionResult New(Animal animal, string IsEditMode)
        {
            try
            {
                if (IsEditMode.Equals("FALSE"))
                {
                    _animalRepository.Create(animal);
                }
                else
                {
                    _animalRepository.Edit(animal);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return Content("Could not add or edit Animal");
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                ViewBag.IsEditMode = "TRUE";
                var animal = _animalRepository.GetSingleAnimal(id);
                return View("new", animal);
            }
            catch (Exception)
            {
                return Content("Couldn't find the animal");
            }

        }
        public IActionResult Delete(int id)
        {
            try
            {
                var animal = _animalRepository.GetSingleAnimal(id);
                _animalRepository.Delete(animal);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return Content("Couldn't delete the animal.");
            }

        }

    }
}