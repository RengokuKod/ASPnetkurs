using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Models
{
    public class Rabotnik
    {
        public int id { get; set; }
        public string? Фамилия { get; set; }
        public string? Имя { get; set; }
        public string? Отчество { get; set; }
        public int Рост { get; set; }
        public string? Должность { get; set; }
        public int Стаж { get; set; }
        public string? Планета_происхождения { get; set; }
        public string? Образование { get; set; }
        public int Возраст { get; set; }
        public string? Фото { get; set; }
    }
  
}
