using Names;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassiveTask
{
    internal class HistogramNew
    {
        public static HistogramData GetHistogramBirthsByLeapsYears(NameData[] names)
        {
            List<int> years = new List<int>();
            char[] vowels = new char[10] { 'а', 'у', 'о', 'ы', 'э', 'я', 'ю', 'ё', 'и', 'е' };
            foreach (var name in names)
            {
                var year = name.BirthDate.Year;
                if ((year % 4 == 0 ^ (year % 100 == 0 && year % 400 != 0))  && !years.Contains(name.BirthDate.Year))
                    years.Add(name.BirthDate.Year);
            }
            years.Sort();
            double[] countBornPeopleNameFirstLetterK = new double[years.Count];
            foreach (var name in names)
            {
                if (!vowels.Contains(name.Name[0]) && years.Contains(name.BirthDate.Year))
                    countBornPeopleNameFirstLetterK[years.IndexOf(name.BirthDate.Year)]++;
            }
            string[] b = new string[years.Count];
            for (int i = 0; i < years.Count; i++)
            {
                b[i] = years[i].ToString();
            }

            return new HistogramData("Рождаемость людей в высокосные года с именами, которые начинаются с согласной буквы", b, countBornPeopleNameFirstLetterK);
        }
    }
}