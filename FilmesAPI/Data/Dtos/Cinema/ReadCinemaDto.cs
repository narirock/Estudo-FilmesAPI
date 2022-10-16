using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Cinema
{
    public class ReadCinemaDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string? Nome { get; set; }

        public FilmesAPI.Models.Endereco? Endereco { get; set; }
    }
}
