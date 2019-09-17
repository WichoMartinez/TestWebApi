using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApi.Models;
using StoreApi.Repository;

namespace StoreApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private IPlaceRepository _repository;
        
        public PlaceController(IPlaceRepository placeRepository)
        {
            _repository = placeRepository;
        }
        // GET: api/GetPlacesByCategory/5
        [HttpGet("GetPlacesByCategory/{CategoryId}")]
        public IActionResult GetPlacesByCategory(int CategoryId)
        {
            var places = _repository.GetAllPlacesByCategory(CategoryId);
            if (places == null)
            {
                return NotFound();
            }
            return Ok(places);
       }

        [HttpGet("GetAll")]
        public IActionResult GetAllPlaces()
        {
            var places = _repository.GetAllPlaces();

            if (places == null)
            {
                return NotFound();
            }
            return Ok(places);
        }

        [HttpGet("{Id}")]
        public IActionResult GetPlace(long id)
        {
            var place = _repository.GetPlace(id);
            if (place == null)
            {
                return NotFound();
            }
            return Ok(place);
        }

        [HttpPost]
        public IActionResult CreatePlace([FromBody] dynamic place)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            Place placeCreated = _repository.CreatePlace(string.Format("{0}",place.name), string.Format("{0}", place.address), Convert.ToInt64(place.category));
                       
            return CreatedAtAction(
                nameof(GetPlace), new { id = placeCreated.Id }, placeCreated);
        }

      
    }
}
