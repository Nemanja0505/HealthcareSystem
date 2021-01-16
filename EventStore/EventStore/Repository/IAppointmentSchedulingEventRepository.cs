﻿using EventStore.Dtos;
using EventStore.Events;
using System.Collections.Generic;

namespace EventStore.Repository
{
    public interface IAppointmentSchedulingEventRepository
    {
        DomainEvent Create(DomainEvent domainEvent);
        long FindNextAttempt();
        IEnumerable<DomainEvent> GetAll();
        public CountStepsEventDto GetStatisticsMinSteps();
        public CountStepsEventDto GetStatisticsMaxSteps();
        public double GetSuccessfulAttemptsRatio();
        public int GetMostCanceledStep();
    }
}