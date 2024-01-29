using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorApp2.Models;

namespace ASP_net_kurs.Data
{
    public class ASP_net_kursContext : DbContext
    {
        public ASP_net_kursContext (DbContextOptions<ASP_net_kursContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorApp2.Models.Posetitel> Posetitel { get; set; } = default!;
        public DbSet<BlazorApp2.Models.Rabotnik> Rabotnik { get; set; } = default!;
        private static readonly Random random = new Random();
        public void GetData()
        {
            if (!Posetitel.Any())
            {
                var data = PosetitelInfo();
                Posetitel.AddRange(data);
                SaveChanges();
            }
        }
        public void GetData2()
        {
            if (!Rabotnik.Any())
            {
                var data = RabotnikInfo();
                Rabotnik.AddRange(data);
                SaveChanges();
            }
        }
        public int Random()
        {
            return random.Next(0, 10);
        }
        public string GetPhoto()
        {
            int random = Random();
            string sourceFolderPath = "..\\ASP net kurs\\wwwroot\\auto\\dataimage";
            string targetFolderPath = "..\\ASP net kurs\\wwwroot\\auto\\dataimagenext";
            string[] files = Directory.GetFiles(sourceFolderPath);
            string sourceFile = files[random];
            string targetFile = Path.Combine(targetFolderPath, Path.GetFileName(sourceFile));

            File.Copy(sourceFile, targetFile, true);

            return Path.Combine("auto", "dataimagenext", Path.GetFileName(sourceFile));
        }
        public List<Posetitel> PosetitelInfo()
        {
            List<string> lines = File.ReadAllLines("..\\ASP net kurs\\wwwroot\\Base\\posetitel.txt").ToList();
            var Posetitel = new List<Posetitel>();

            foreach (var line in lines)
            {
                var photo = GetPhoto();
                string[] spl = line.Split(';');
                var posetitel = new Posetitel
                {
                    Фамилия = spl[0],
                    Имя = spl[1],
                    Отчество = spl[2],
                    Возраст = Convert.ToInt32(spl[3]),
                    Размер_багажа = spl[4],
                    Судимость = Convert.ToBoolean(spl[5]),
                    Комната = spl[6],
                    Питомец = Convert.ToBoolean(spl[7]),
                    Мини_бар = Convert.ToBoolean(spl[8]),
                    Фото = photo
                };
                Posetitel.Add(posetitel);
            }
            return Posetitel;
        }
        public string GetPhoto2()
        {
            int random = Random();
            string sourceFolderPath = "..\\ASP net kurs\\wwwroot\\auto\\rabotnik";
            string targetFolderPath = "..\\ASP net kurs\\wwwroot\\auto\\rabotniknext";
            string[] files = Directory.GetFiles(sourceFolderPath);
            string sourceFile = files[random];
            string targetFile = Path.Combine(targetFolderPath, Path.GetFileName(sourceFile));

            File.Copy(sourceFile, targetFile, true);

            return Path.Combine("auto", "rabotniknext", Path.GetFileName(sourceFile));
        }
        public List<Rabotnik> RabotnikInfo()
        {
            List<string> lines = File.ReadAllLines("..\\ASP net kurs\\wwwroot\\Base\\rabotnik.txt").ToList();
            var Rabotnik = new List<Rabotnik>();

            foreach (var line in lines)
            {
                var photo = GetPhoto2();
                string[] spl = line.Split(';');
                var rabotnik = new Rabotnik
                {
                    Фамилия = spl[0],
                    Имя = spl[1],
                    Отчество = spl[2],
                    Рост = Convert.ToInt32(spl[3]),
                    Должность = spl[4],
                    Стаж = Convert.ToInt32(spl[5]),
                    Планета_происхождения = spl[6],
                    Образование = spl[7],
                    Возраст = Convert.ToInt32(spl[8]),
                    Фото = photo
                };
                Rabotnik.Add(rabotnik);
            }
            return Rabotnik;
        }
    }
}

