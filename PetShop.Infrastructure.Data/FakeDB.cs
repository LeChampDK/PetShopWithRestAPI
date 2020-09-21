using System;
using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data
{
    public class FakeDB
    {
        static int id = 1;
        public static List<Pet> _pets = new List<Pet>();

        public static void InitData()
        {
            Pet pet1 = new Pet()
            {
                PetId = id++,
                PetName = "Jennifurr",
                PetType = "Cat",
                PetBirthdate = DateTime.Parse("2020-03-03"),
                PetSoldDate = DateTime.Parse("2020-03-04"),
                PetColor = "Black",
                PetPreviousOwner = "Paul",
                PetPrice = 99995
            };
            _pets.Add(pet1);

            Pet pet2 = new Pet()
            {
                PetId = id++,
                PetName = "Meowsie",
                PetType = "Cat",
                PetBirthdate = DateTime.Parse("2015-09-09"),
                PetSoldDate = DateTime.Parse("2001-10-09"),
                PetColor = "Yellow",
                PetPreviousOwner = "Kenny",
                PetPrice = 1000
            };
            _pets.Add(pet2);

            Pet pet3 = new Pet()
            {
                PetId = id++,
                PetName = "Purrito",
                PetType = "Cat",
                PetBirthdate = DateTime.Parse("2012-05-05"),
                PetSoldDate = DateTime.Parse("2013-06-06"),
                PetColor = "Brown",
                PetPreviousOwner = "Cindy Clawford",
                PetPrice = 5000
            };
            _pets.Add(pet3);

            Pet pet4 = new Pet()
            {
                PetId = id++,
                PetName = "Katy Purry",
                PetType = "Cat",
                PetBirthdate = DateTime.Parse("2010-01-01"),
                PetSoldDate = DateTime.Parse("2011-07-07"),
                PetColor = "Pink",
                PetPreviousOwner = "Shark",
                PetPrice = 1000000
            };
            _pets.Add(pet4);

            Pet pet5 = new Pet()
            {
                PetId = id++,
                PetName = "Peanut",
                PetType = "Dog",
                PetBirthdate = DateTime.Parse("2019-04-04"),
                PetSoldDate = DateTime.Parse("2001-05-05"),
                PetColor = "Green",
                PetPreviousOwner = "Alfred von Wigglebottom",
                PetPrice = 2000
            };
            _pets.Add(pet5);

            Pet pet6 = new Pet()
            {
                PetId = id++,
                PetName = "Biscuit",
                PetType = "Dog",
                PetBirthdate = DateTime.Parse("2018-07-07"),
                PetSoldDate = DateTime.Parse("2001-08-08"),
                PetColor = "Blue",
                PetPreviousOwner = "Miss Furbulous",
                PetPrice = 15000
            };
            _pets.Add(pet6);

            Pet pet7 = new Pet()
            {
                PetId = id++,
                PetName = "Cheeseburger",
                PetType = "Dog",
                PetBirthdate = DateTime.Parse("2016-10-10"),
                PetSoldDate = DateTime.Parse("2017-11-12"),
                PetColor = "Grey",
                PetPreviousOwner = "Jellybean",
                PetPrice = 100
            };
            _pets.Add(pet7);

            Pet pet8 = new Pet()
            {
                PetId = id++,
                PetName = "Barkley",
                PetType = "Dog",
                PetBirthdate = DateTime.Parse("2019-05-05"),
                PetSoldDate = DateTime.Parse("2001-06-06"),
                PetColor = "Purple",
                PetPreviousOwner = "Mister Fluffers",
                PetPrice = 3000
            };
            _pets.Add(pet8);

            Pet pet9 = new Pet()
            {
                PetId = id++,
                PetName = "Slimy",
                PetType = "Snake",
                PetBirthdate = DateTime.Parse("2016-09-09"),
                PetSoldDate = DateTime.Parse("2016-12-12"),
                PetColor = "Black",
                PetPreviousOwner = "Psycho",
                PetPrice = 5
            };
            _pets.Add(pet9);
        }

        public List<Pet> GetPets()
        {
            return _pets;
        }

        public void AddPet(Pet pet)
        {
            _pets.Add(pet);
        }

        public void RemovePet(Pet pet)
        {
            _pets.Remove(pet);
        }

        public int GetPetId()
        {
            return id;
        }

    }
}