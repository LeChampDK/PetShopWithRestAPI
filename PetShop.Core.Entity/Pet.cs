using System;

namespace PetShop.Core.Entity
{
    public class Pet
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
        public DateTime PetBirthdate { get; set; }
        public DateTime? PetSoldDate { get; set; }
        public string PetColor { get; set; }
        public string PetPreviousOwner { get; set; }
        public double PetPrice { get; set; }
    }
}
