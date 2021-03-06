using System.Collections.Generic;
using Pet.Models;

namespace Pet.Repository
{
    public interface IAnimalRepository
    {
        void Create(Animal Animal);
        void Edit(Animal animal);
        Animal GetSingleAnimal(int id);
        void Delete(Animal animal);
        List<Animal> GetAllAnimals();

        bool VerifyName(string name);
        List<Animal> SearchAnimal(string search);
    }
}