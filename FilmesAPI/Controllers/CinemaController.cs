using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Cinema;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController:ControllerBase    
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]  
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto )
        {
            Cinema cinema = _mapper.Map<Cinema>( cinemaDto );
            _context.Cinema.Add(cinema);
            _context.SaveChanges(); 
            return Ok(cinema);
        }

        [HttpGet]
        public IActionResult RecuperarCinema()
        {
            return Ok(_context.Cinema);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPorId(int id)
        {
            Cinema? cinema = _context.Cinema.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(cinemaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FormBody] UpdateCinemaDto cinemaDto)
        {
            Cinema? cinema = _context.Cinema.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return BadRequest();
            }

            cinema = _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Cinema? cinema = _context.Cinema.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema == null)
            {
                return NotFound();  
            }

            _context.Remove(cinema);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
