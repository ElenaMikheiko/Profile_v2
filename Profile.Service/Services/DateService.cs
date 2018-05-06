using Profile.DataAccess.Data;
using Profile.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Profile.Service.Services
{
    public class DateService : IDateService
    {
        private ProfileDbContext _db;

        public DateService(ProfileDbContext db)
        {
            _db = db;
        }

        public Dictionary<int,string> GetAllMonths()
        {
            List<string> months = new List<string>();
            for (int i = 0; i < 12; i++)
            {
                months.Add(CultureInfo.GetCultureInfoByIetfLanguageTag("EN").DateTimeFormat.MonthNames[i]);
            }
            months.Insert(0, "");
            return months.Select((name, number) => new { number, name }).ToDictionary(x => x.number, x => x.name);
        }

        public IEnumerable<int> GetAllYears()
        {
            IEnumerable<int> years = Enumerable.Range((DateTime.Now.Year) - 20, 40);

            return years.OrderByDescending(y=>y);
        }
    }
}
