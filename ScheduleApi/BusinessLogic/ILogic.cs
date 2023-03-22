using FluentApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ILogic
    {
        public void AddSchedule(DoctorSchedule doctorSchedule);

        public DoctorSchedule? UpdateSchedule(int day, DoctorSchedule doctorSchedule);

        public IEnumerable<DoctorSchedule>? GetSchedule(string day);
    }
}
