using Microsoft.AspNetCore.Mvc;
using Pet.Data;
using Pet.Models;
using Pet.Repository;

namespace Pet.Controllers
{
    class AnimalController: Controller
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
            var animals = _animalRepository.GetAllAnimals();
            return View(animals);
        }

        public IActionResult Details(int id)
        {
            var animals = _animalRepository.GetSingleAnimal(id);
            return View(animals);
        }

        [HttpGet]
        public IActionResult New()
        {
            var animals = new Animal();
            return View(animals);
        }

        [HttpPost]
        public IActionResult New(Animal animal)
        {
            _animalRepository.Create(animal);
            return View();
        }

        public IActionResult Delete(int id)
        {
            var  animal = _animalRepository.GetSingleAnimal(id);
            _animalRepository.Delete(animal);
            return View();
        }

    }
}