using FitnessTrackerClientApp.Enumeration;
using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerClientApp.DTO
{
    [Serializable]
    public class UserDTO
    {
        public string Name { get; set; }
  
        public DateTime DateofBirth { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public decimal Height { get; set; }
        
    }
}
