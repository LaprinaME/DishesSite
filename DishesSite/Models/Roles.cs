using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DishesSite.Models
{
    public class Roles
    {
        [Key] public int Код_роли { get; set; }
        public string Название_роли { get; set; }
    }
}
