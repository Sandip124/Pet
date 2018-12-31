using System.Collections.Generic;
using System.Linq;
using Pet.Data;
using Pet.Models;

namespace Pet.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private ApplicationDbContext _context;

        public AnimalRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Animal animal)
        {
           _context.Animals.Add(animal);
            _context.SaveChanges();    
        }

        public void Delete(Animal animal)
        {
            _context.Animals.Remove(animal);
            _context.SaveChanges();
        }

        public void Edit(Animal animal)
        {
            _context.Animals.Update(animal);
            _context.SaveChanges();
        }

        public List<Animal> GetAllAnimals()
        {
            return _context.Animals.ToList();
        }

        public Animal GetSingleAnimal(int id)
        {
            var animal = _context.Animals.FirstOrDefault(a=>a.Id == id);
            return animal;
        }

        public bool VerifyName(string name)
        {
            return _context.Animals.Any(a=>a.Name == name);

        }
    }
}
