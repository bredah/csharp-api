using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DataProduct.Models
{
    public class Book
    {
        [Required]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("gender")]
        public Gender Gender { get; set; }
        [JsonProperty("writer")]
        public string Writer { get; set; }
    }
}