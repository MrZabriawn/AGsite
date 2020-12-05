using System;
using System.ComponentModel.DataAnnotations;

namespace AGsite.Models
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string News { get; set; }

    }
}