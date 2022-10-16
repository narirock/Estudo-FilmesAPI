﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Cinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe um endereço")]
        public int EnderecoId { get; set; }
    }
}
