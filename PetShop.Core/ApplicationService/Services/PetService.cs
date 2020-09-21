using System;
using System.Collections.Generic;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet NewPet(string petName, string petType, DateTime petBirthDate, DateTime petSoldDate, string petColor, string petPreviousOwner, double petPrice)
        {
            var pet = new Pet
            {
                PetName = petName,
                PetType = petType,
                PetBirthdate = petBirthDate,
                PetSoldDate = petSoldDate,
                PetColor = petColor,
                PetPreviousOwner = petPreviousOwner,
                PetPrice = petPrice
            };

            return pet;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepository.CreatePet(pet);
        }

        public Pet DeletePet(int petId)
        {
            return _petRepository.DeletePet(petId);
        }

        public Pet EditPet(Pet petEdit)
        {
            Pet pet = FindPetByIdI(petEdit.PetId);
            pet.PetName = petEdit.PetName;
            pet.PetType = petEdit.PetType;
            pet.PetBirthdate = petEdit.PetBirthdate;
            pet.PetSoldDate = petEdit.PetSoldDate;
            pet.PetColor = petEdit.PetColor;
            pet.PetPreviousOwner = petEdit.PetPreviousOwner;
            pet.PetPrice = petEdit.PetPrice;

            return pet;
        }

        public Pet FindPetByIdI(int petId)
        {
            return _petRepository.GetByPetId(petId);
        }

        public List<Pet> GetPets()
        {
            return _petRepository.GetPets();
        }

        public List<Pet> GetPetsByType(string petType)
        {
            return _petRepository.GetPetsByType(petType);
        }

        public List<Pet> GetPetsByPrice()
        {
            return _petRepository.GetPetsByPrice();
        }

        public Pet UpdatePet(Pet updatePet)
        {
            var pet = FindPetByIdI(updatePet.PetId);

            pet.PetName = updatePet.PetName;
            pet.PetType = updatePet.PetType;
            pet.PetBirthdate = updatePet.PetBirthdate;
            pet.PetSoldDate = updatePet.PetSoldDate;
            pet.PetColor = updatePet.PetColor;
            pet.PetPreviousOwner = updatePet.PetPreviousOwner;
            pet.PetPrice = updatePet.PetPrice;

            return pet;
        }
    }
}