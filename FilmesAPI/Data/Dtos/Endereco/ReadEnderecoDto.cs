﻿using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos.Endereco
{
    public class ReadEnderecoDto
    {
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public int Numero { get; set; }

        public FilmesAPI.Models.Cinema Cinema { get; set; }
    }
}
