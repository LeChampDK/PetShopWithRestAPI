using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        Pet CreatePet(Pet pet);
        Pet DeletePet(int petId);
        Pet GetByPetId(int petId);
        List<Pet> GetPets();
        Pet EditPet(Pet petEdit);
        List<Pet> GetPetsByType(string petType);
        List<Pet> GetPetsByPrice();
    }
}
