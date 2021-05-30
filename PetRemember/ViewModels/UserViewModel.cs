using PetRemember.Domain.Pets;
using PetRemember.Domain.Products;
using PetRemember.Domain.Users;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PetRemember.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public string Password { get; set; }
        public string Month { get; set; }
        public int[,] Weeks = new int[6, 7];
        public UserViewModel()
        {
            Month = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            Month = char.ToUpper(Month[0]) + Month.Substring(1);
            var firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            int i = 0;
            switch (firstDayOfMonth.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    i = 7;
                    Weeks[0, 0] = 0;
                    Weeks[0, 1] = 0;
                    Weeks[0, 2] = 0;
                    Weeks[0, 3] = 0;
                    Weeks[0, 4] = 0;
                    Weeks[0, 5] = 0;
                    Weeks[0, 6] = 0;
                    break;
                case DayOfWeek.Tuesday:
                    i = 1;
                    Weeks[0, 0] = 0;
                    break;
                case DayOfWeek.Wednesday:
                    i = 2;
                    Weeks[0, 0] = 0;
                    Weeks[0, 1] = 0;
                    break;
                case DayOfWeek.Thursday:
                    i = 3;
                    Weeks[0, 0] = 0;
                    Weeks[0, 1] = 0;
                    Weeks[0, 2] = 0;
                    break;
                case DayOfWeek.Friday:
                    i = 4;
                    Weeks[0, 0] = 0;
                    Weeks[0, 1] = 0;
                    Weeks[0, 2] = 0;
                    Weeks[0, 3] = 0;
                    break;
                case DayOfWeek.Saturday:
                    i = 5;
                    Weeks[0, 0] = 0;
                    Weeks[0, 1] = 0;
                    Weeks[0, 2] = 0;
                    Weeks[0, 3] = 0;
                    Weeks[0, 4] = 0;
                    break;
                case DayOfWeek.Sunday:
                    i = 6;
                    Weeks[0, 0] = 0;
                    Weeks[0, 1] = 0;
                    Weeks[0, 2] = 0;
                    Weeks[0, 3] = 0;
                    Weeks[0, 4] = 0;
                    Weeks[0, 5] = 0;
                    break;
            }
            for (int j = i; j < DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) + i; j++)
            {
                Weeks[j / 7, j % 7] = j - i + 1;
            }
        }
    }
}
