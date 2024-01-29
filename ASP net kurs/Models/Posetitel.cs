using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Models
{
    public class Posetitel
    {
        public int id { get; set; }
        public string? Фамилия { get; set; }
        public string? Имя { get; set; }
        public string? Отчество { get; set; }
        public int Возраст { get; set; }
        public string? Размер_багажа { get; set; }
        public bool Судимость { get; set; }
        public string? Комната { get; set; }
        public bool Питомец { get; set; }
        public bool Мини_бар { get; set; }
        public string? Фото { get; set; }
    }
}
