using System;

namespace EmployeesManager.Infrastructure.IoC
{
    public static class DateTimeExtensions
    {
        public static bool IsOfAge(this DateTime BirthDate)
        {
            var now = DateTime.Now;
            return ((now.Year - BirthDate.Year) > 18 ||
                ((now.Year - BirthDate.Year) == 18 && now.DayOfYear - BirthDate.DayOfYear >= 0));
        }
    }
}
