using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        // GET: api/<PetController>
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            var pets = _petService.GetPets();
            return pets;
        }

        // GET api/<PetController>/5
        [HttpGet("{id}")]
        public Pet Get(int id)
        {
            return _petService.FindPetByIdI(id);
        }

        // POST api/<PetController>
        [HttpPost]
        public Pet Post([FromBody] Pet pet)
        {
            var creatPet = _petService.CreatePet(pet);
            return creatPet;
        }

        // PUT api/<PetController>/5
        [HttpPut("{id}")]
        public Pet Put(int id, [FromBody] Pet pet)
        {
            pet.PetId = id;
            Pet updatedPet = _petService.UpdatePet(pet);
            return updatedPet;
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public Pet Delete(int id)
        {
            Pet deletedPet = _petService.DeletePet(id);
            return deletedPet;
        }
    }
}
