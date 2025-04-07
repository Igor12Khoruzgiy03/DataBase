using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
    public class Massage
    {
        public int Id { get; set; }
        public string Name { get; set; } // Название массажа (например, "Desert")
        public string Description { get; set; } // Описание массажа
        public string ImageUrl { get; set; } // Путь к изображению
        public decimal Price { get; set; } // Цена
    }

}
