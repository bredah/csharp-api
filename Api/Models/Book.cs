using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Book
    {
        [JsonProperty("id")]
        [Required]
        public Guid Id { get; set; }

        [JsonProperty("title")]
        [Required, StringLength(20, MinimumLength = 10, ErrorMessage = "Invalid value")]
        public string Title { get; set; }

        [Required, StringLength(30, MinimumLength = 10, ErrorMessage = "Invalid value")]
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("genre")]
        [Required]
        public Genre Genre { get; set; }
    }
}