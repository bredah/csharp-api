using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Api.Models
{
    public class Book
    {
        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("genre")]
        public Genre Genre { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
    }
}