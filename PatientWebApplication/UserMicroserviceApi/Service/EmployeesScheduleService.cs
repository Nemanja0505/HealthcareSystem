/***********************************************************************
 * Module:  EmployeesSchedule.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.EmployeesSchedule
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UserMicroserviceApi.Model;
using UserMicroserviceApi.Repository;

namespace UserMicroserviceApi.Service
{
    public class EmployeesScheduleService : IService<Schedule>
    {
        public IEmployeesScheduleRepository _employeesScheduleRepository;


        public EmployeesScheduleService(IEmployeesScheduleRepository employeesScheduleRepository)
        {
            _employeesScheduleRepository = employeesScheduleRepository;
        }

        public void New(Schedule schedule)
        {
            _employeesScheduleRepository.New(schedule);

        }

        public void Update(Schedule schedule)
        {
            _employeesScheduleRepository.Update(schedule);
        }

        public void Remove(Schedule schedule)
        {
            _employeesScheduleRepository.Delete(schedule.id);
        }

        public List<Schedule> GetAll()
        {
            return _employeesScheduleRepository.GetAll();

        }

        private bool isScheduleForDoctor(Schedule schedule, DoctorUser doctor)
        {
            if (schedule.EmployeeId == doctor.id) return true;
            return false;
        }

        private Shift getScheduleShiftForDoctor(DoctorUser doctor, string date, Schedule schedule)
        {
            if (isScheduleForDoctor(schedule, doctor) && schedule.date.Equals(date)) return schedule.shift;
            return null;
        }

        public Shift getShiftForDoctorForSpecificDay(string date, DoctorUser doctor)
        {
            if (doctor == null)
            {
                return null;
            }
            foreach (Schedule schedule in _employeesScheduleRepository.GetAll())
            {
                if (getScheduleShiftForDoctor(doctor, date, schedule) != null) return getScheduleShiftForDoctor(doctor, date, schedule);
            }
            return null;
        }

        public bool isTimeInGoodFormat(string start, string end)
        {
            if (!Regex.Match(start, "^[0-9]{2}:[0-9]{2}$").Success || !Regex.Match(end, "^[0-9]{2}:[0-9]{2}$").Success) return false;

            string[] startParts = start.Split(':');
            string[] endParts = end.Split(':');

            if (int.Parse(startParts[0]) > 23 || int.Parse(startParts[1]) > 60 || int.Parse(endParts[0]) > 23 || int.Parse(endParts[1]) > 60 || int.Parse(startParts[0]) > int.Parse(endParts[0])) return false;

            return true;
        }

        public bool isDoctorWorkingAtSpecifiedTime(string date, DoctorUser doctor, TimeSpan time)
        {
            Shift shift = getShiftForDoctorForSpecificDay(date, doctor);

            int areSelectedTimeAndStartTimeOfShiftEqual = TimeSpan.Compare(time, getStartTime(shift.startTime));
            int areSelectedTimeAndEndTimeOfShiftEqual = TimeSpan.Compare(time, getEndTime(shift.endTime));

            if (areSelectedTimeAndStartTimeOfShiftEqual == 1 && areSelectedTimeAndEndTimeOfShiftEqual == -1 || areSelectedTimeAndStartTimeOfShiftEqual == 0) return true;

            return false;
        }

        private TimeSpan getEndTime(string endTime)
        {
            string[] endParts = endTime.Split(':');
            return new TimeSpan(int.Parse(endParts[0]), int.Parse(endParts[1]), int.Parse("00"));
        }

        private TimeSpan getStartTime(string startTime)
        {
            string[] startParst = startTime.Split(':');
            return new TimeSpan(int.Parse(startParst[0]), int.Parse(startParst[1]), int.Parse("00"));
        }

        public Schedule GetByid(int id)
        {
            return _employeesScheduleRepository.GetByid(id);
        }
    }
}