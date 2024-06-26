﻿using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerServerApp.DTO
{
    [Serializable]
    public class LoginUserDTO
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
