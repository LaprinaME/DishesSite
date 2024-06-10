﻿using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DishesSite.Models
{
    // Модель для таблицы "Аккаунты"
    public class Accounts
    {
        [Key]
        public int Код_аккаунта { get; set; } // Код_аккаунта

        [Required]
        [StringLength(255)]
        public string Логин { get; set; } // Логин

        [Required]
        [StringLength(255)]
        public string Пароль { get; set; } // Пароль
        [ForeignKey("Код_роли")]
        public Roles Роли { get; set; }
    }
}