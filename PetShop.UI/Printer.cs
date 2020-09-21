using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;

namespace PetShop.UI
{
    public class Printer : IPrinter
    {
        IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
        }

        public void StartUI()
        {
            Console.WriteLine("Select a option by typing the number on the left");
            Console.WriteLine("1: Pet List");
            Console.WriteLine("2: Create Pet");
            Console.WriteLine("3: Edit Pet");
            Console.WriteLine("4: Delete Pet");
            Console.WriteLine("5: Search pets by type");
            Console.WriteLine("6: Sort pets by priice");
            Console.WriteLine("7: List cheapest pets");
            Console.WriteLine("\n0: Exit");

            string numberChosen = Console.ReadLine();
            bool isNumber = int.TryParse(numberChosen, out int number);

            if (isNumber)
            {
                int numberChosen1 = int.Parse(numberChosen);
                while (numberChosen1 > 0)
                {
                    switch (numberChosen1)
                    {
                        case 1:

                            Console.WriteLine("Pet list\n");
                            var pets = _petService.GetPets();
                            ListPets(pets);

                            StartUI();
                            break;

                        case 2:
                            Console.WriteLine("Please write the name of the Pet");
                            string petName = Console.ReadLine();
                            Console.WriteLine("Please write the type of pet");
                            string petType = Console.ReadLine();
                            Console.WriteLine("Please write the birthdate of the pet");
                            DateTime birthDate = DateTimeValidator();
                            Console.WriteLine("Please write the sold date of the pet");
                            DateTime soldDate = DateTimeValidator();
                            Console.WriteLine("Please write the color of the pet");
                            string petColor = Console.ReadLine();
                            Console.WriteLine("Please write the previous owner of the pet");
                            string petPreviousOwner = Console.ReadLine();
                            Console.WriteLine("Please write the price of the pet");
                            string petPrice = Console.ReadLine();
                            int convertedPrice = int.Parse(petPrice);

                            Pet newPet = _petService.NewPet(petName, petType, birthDate, soldDate, petColor, petPreviousOwner, convertedPrice);
                            _petService.CreatePet(newPet);
                            Console.WriteLine("Your pet has been created\n");
                            StartUI();
                            break;

                        case 3:
                            var petIdToEdit = FindPetID();
                            var petToEdit = _petService.FindPetByIdI(petIdToEdit);
                            Console.WriteLine($"Pet chosen to update: {petToEdit.PetName}");
                            Console.WriteLine("Please write the name of the Pet");
                            var newName = Console.ReadLine();
                            Console.WriteLine("Please write the type of pet");
                            var newType = Console.ReadLine();
                            Console.WriteLine("Please write the birthdate of the pet");
                            var newBirthDate = DateTimeValidator();
                            Console.WriteLine("Please write the sold date of the pet");
                            var newSoldDate = DateTimeValidator();
                            Console.WriteLine("Please write the color of the pet");
                            var newColor = Console.ReadLine();
                            Console.WriteLine("Please write the previous owner of the pet");
                            var newPreviousOwner = Console.ReadLine();
                            Console.WriteLine("Please write the price of the pet");
                            var newPrice = DoubbleValidator();

                            _petService.EditPet(new Pet()
                            {
                                PetId = petIdToEdit,
                                PetName = newName,
                                PetType = newType,
                                PetBirthdate = newBirthDate,
                                PetSoldDate = newSoldDate,
                                PetColor = newColor,
                                PetPreviousOwner = newPreviousOwner,
                                PetPrice = newPrice
                            });
                            StartUI();
                            break;

                        case 4:
                            var petIdToDelete = FindPetID();
                            _petService.DeletePet(petIdToDelete);

                            StartUI();
                            break;

                        case 5:
                            Console.WriteLine("Search pets of type:");
                            var sortType = Console.ReadLine();
                            List<Pet> typeSortedPets = _petService.GetPetsByType(sortType);
                            ListPets(typeSortedPets);

                            StartUI();
                            break;

                        case 6:
                            List<Pet> sortPrice = _petService.GetPetsByPrice();
                            ListPets(sortPrice);

                            StartUI();
                            break;

                        case 7:
                            List<Pet> sortedByPrice5 = _petService.GetPetsByPrice();
                            List5Pets(sortedByPrice5);

                            StartUI();
                            break;

                        default:
                            Console.WriteLine("Please select a valid option\n\n");
                            StartUI();
                            break;
                    }
                    break;
                }
            }
            else
            {
                Console.WriteLine("Please input a number");
                StartUI();
            }

        }

        void ListPets(List<Pet> pets)
        {
            Console.WriteLine("\nList of Pets");
            foreach (var pet in pets)
            {
                Console.WriteLine($" Id: {pet.PetId} \n " +
                                  $"Pet Name: {pet.PetName} \n " +
                                  $"Pet type: {pet.PetType} \n " +
                                  $"Pet birthdate: {pet.PetBirthdate} \n " +
                                  $"Pet sold date: {pet.PetSoldDate} \n " +
                                  $"Pet color: {pet.PetColor} \n " +
                                  $"Pet previous owner: {pet.PetPreviousOwner} \n " +
                                  $"Pet price: {pet.PetPrice} \n");
            }
            Console.WriteLine("\n");

        }

        void List5Pets(List<Pet> pets)
        {
            for (int i = 0; i < 5; i++)
            {
                var pet = pets[i];
                Console.WriteLine($" Pet ID: {pet.PetId} \n " +
                                  $"Pet Name: {pet.PetName} \n " +
                                  $"Pet Type: {pet.PetType} \n " +
                                  $"Pet Birthday: {pet.PetBirthdate} \n " +
                                  $"Pet Sold: {pet.PetSoldDate} \n " +
                                  $"Pet color: {pet.PetColor} \n " +
                                  $"Previous Owner: {pet.PetPreviousOwner} \n " +
                                  $"Pet Price: {pet.PetPrice} kr. \n");
            }
        }
        int FindPetID()
        {
            Console.WriteLine("Type a Pet ID : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Not a valid ID");
            }
            return id;
        }
        DateTime DateTimeValidator()
        {
            DateTime datetime;
            while (!DateTime.TryParse(Console.ReadLine(), out datetime))
            {
                Console.WriteLine("Not a valid date, try again");
            }
            return datetime;
        }
        double DoubbleValidator()
        {
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Price must be a number");
            }
            return price;
        }
    }
}
