using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebParser.Models
{
    public class Response
    {
        
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("date_published")]
        public DateTime DatePublished { get; set; } = DateTime.MinValue;
        [JsonProperty("lead_image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty("dek")]
        public string Dek { get; set; }
        [JsonProperty("next_page")]
        public string NextPageUrl { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("domain")]
        public string Domain { get; set; }
        [JsonProperty("excerpt")]
        public string Excerpt { get; set; }
        [JsonProperty("word_count")]
        public int WordCount { get; set; }
        [JsonProperty("direction")]
        public string Direction { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty("rendered_pages")]
        public int RenderedPages { get; set; }

    }
}