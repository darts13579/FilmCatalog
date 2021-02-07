using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;

namespace FilmCatalogCore.Models
{
    public class FilmCreateModel
    {
        [Required (ErrorMessage = "Не указано название фильма")]
        [StringLength(40, ErrorMessage = "Длина названия должна быть до 40 символов")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Не указано описание фильма")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Длина описания должна быть до 500 символов")]
        public string Description { get; set; }

        [Required (ErrorMessage = "Не указан автор фильма")]
        [StringLength(40, ErrorMessage = "Длина автора должна быть до 40 символов")]
        public string Producer { get; set; }

        [Range(1895, 2021, ErrorMessage = "Недопустимый год выпуска фильма")]
        public int Year { get; set; }

        public IFormFile Image { get; set; }
    }
}