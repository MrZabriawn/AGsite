using System;
using System.ComponentModel.DataAnnotations;

namespace AGsite.Models
{
    public class SurveyData
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string YearsHere { get; set; }
        public string Answer { get; set; }
    }
}