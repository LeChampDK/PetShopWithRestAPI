using System;
using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        Pet NewPet(string petName, string petType, DateTime petBirthDate, DateTime petSoldDate, string petColor,
            string petPreviousOwner, double petPrice);
        Pet CreatePet(Pet pet);
        Pet DeletePet(int petId);
        Pet EditPet(Pet petEdit);
        Pet FindPetByIdI(int petId);
        List<Pet> GetPets();
        Pet UpdatePet(Pet updatePet);
        List<Pet> GetPetsByPrice();
        List<Pet> GetPetsByType(string petType);

    }
}