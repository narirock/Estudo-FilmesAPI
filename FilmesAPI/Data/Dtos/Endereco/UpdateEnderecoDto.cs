using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Endereco
{
    public class UpdateEnderecoDto
    {
        [Required(ErrorMessage = "O campo logradouro é obrigatório")]
        public string? Logradouro { get; set; }
        [Required(ErrorMessage = "O campo bairro é obrigatório")]
        public string? Bairro { get; set; }
        [Required(ErrorMessage = "O campo número é obrigatório")]
        public int Numero { get; set; }
    }
}
