using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Profile.Model.Models
{
    public class UserInfo:BaseModel
    {       
        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [MaxLength(30)]
        public string RuName { get; set; }

        [MaxLength(50)]
        public string RuSurname { get; set; }

        [MaxLength(30)]
        public string EnName { get; set; }

        [MaxLength(50)]
        public string EnSurname { get; set; }

        public string Phone { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public byte [] Photo { get; set; }

        public string GoogleApiKey { get; set; }

        [MaxLength(30)]
        public string Skype { get; set; }

        [MaxLength(150)]
        public string Linkedin { get; set; }

    }
}
