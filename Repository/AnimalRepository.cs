using System.Collections.Generic;
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
        public void Create(Animal Animal)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Animal animal)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(Animal animal)
        {
            throw new System.NotImplementedException();
        }

        public List<Animal> GetAllAnimals()
        {
            throw new System.NotImplementedException();
        }

        public Animal GetSingleAnimal(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
