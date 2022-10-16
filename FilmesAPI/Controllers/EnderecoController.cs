using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Endereco;
using FilmesAPI.Models;
using FilmesAPI.Profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController:ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;    
        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarEnderco([FromBody]CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Endereco.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { Id = endereco.Id}, endereco);
        }

        [HttpGet]
        public IActionResult RecuperarEndereco()
        {

            return Ok(_context.Endereco);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoPorId(int id)
        {
            Endereco? endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco == null)
            {
                return NotFound();
            }
            ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
            return Ok(enderecoDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco? endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return BadRequest();
            }

            endereco = _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteEndereco(int id)
        {
            Endereco? endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return BadRequest();
            }

            _context.Remove(endereco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
