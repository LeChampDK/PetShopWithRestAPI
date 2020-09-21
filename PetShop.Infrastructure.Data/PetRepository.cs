using PetShop.Core.DomainService;
using System;
using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository 
    {

        private FakeDB _fakeDB = new FakeDB();

        public Pet CreatePet(Pet pet)
        {
            pet.PetId = _fakeDB.GetPetId();
            _fakeDB.AddPet(pet);
            return pet;
        }

        public Pet DeletePet(int petId)
        {
            var pet = this.GetByPetId(petId);
            if (pet != null)
            {
                _fakeDB.RemovePet(pet);
                return pet;
            }
            return null;
        }

        public Pet GetByPetId(int petId)
        {
            foreach (var pet in _fakeDB.GetPets())
            {
                if (pet.PetId == petId)
                {
                    return pet;
                }
            }
            return null;
        }

        public Pet EditPet(Pet petEdit)
        {
            var petFromDB = this.GetByPetId(petEdit.PetId);
            if (petFromDB != null)
            {
                petFromDB.PetName = petEdit.PetName;
                petFromDB.PetType = petEdit.PetType;
                petFromDB.PetBirthdate = petEdit.PetBirthdate;
                petFromDB.PetSoldDate = petEdit.PetSoldDate;
                petFromDB.PetColor = petEdit.PetColor;
                petFromDB.PetPreviousOwner = petEdit.PetPreviousOwner;
                petFromDB.PetPrice = petEdit.PetPrice;

                return petFromDB;
            }
            return null;
        }

        
        public List<Pet> GetPets()
        {
            return _fakeDB.GetPets();
        }

        public List<Pet> GetPetsByPrice()
        {
            List<Pet> sortPets = _fakeDB.GetPets();

            sortPets.Sort((x, y) => x.PetPrice.CompareTo(y.PetPrice));

            return sortPets;
        }

        public List<Pet> GetPetsByType(string petType)
        {
            List<Pet> petsByType = new List<Pet>();
            foreach (var pet in _fakeDB.GetPets())
            {
                if (pet.PetType.ToLower() == petType.ToLower())
                {
                    petsByType.Add(pet);
                }
            }
            return petsByType;
        }
    }
}
