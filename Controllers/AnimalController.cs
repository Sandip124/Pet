using System;
using ClientNotifications;
using Microsoft.AspNetCore.Mvc;
using Pet.Data;
using Pet.Models;
using Pet.Repository;
using static ClientNotifications.Helpers.NotificationHelper;

namespace Pet.Controllers
{
    public class AnimalController : Controller
    {
        private IAnimalRepository _animalRepository;

        private IClientNotification _clientNotification;

        public AnimalController(IClientNotification clientNotification,
                                IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
            _clientNotification = clientNotification;
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

                    _clientNotification.AddSweetNotification("Success",
                                  "Animal detail added Successfully.",
                                  NotificationType.success);
                }
                else
                {
                    _animalRepository.Edit(animal);

                    _clientNotification.AddSweetNotification("Success",
                                 "Animal detail updated Successfully.",
                                 NotificationType.success);
                    
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                _clientNotification.AddSweetNotification("Error",
                                "Could not add or edit Animal",
                                NotificationType.error);
                return RedirectToAction(nameof(Index));

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

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}