﻿using Business.Service;
using System;
using Entities;
using System.Linq;

namespace Business
{
    public enum ActivityEnum
    {
        Arrived = 1,
        Exercise = 2,
        Cage = 3,
        Left = 4
    }
    public enum AreaType
    {
        Cage = 1,
        Exercise = 2
    }
    public enum Status
    {
        Available = 1,
        Unavailable = 2
    }
    public class Simulator
    {
        HamsterService hamsterService = new HamsterService();
        AreaService areaService = new AreaService();
        ActivityLogService activityLogService = new ActivityLogService();
        public void CheckIn()
        {
            if (Tick.simulatorDate.Hour == 07 && Tick.simulatorDate.Minute == 0)
            {
                var hamsterList = hamsterService.GetAll();
                foreach (var hamster in hamsterList)
                {
                    int areaId = GetAreaId(hamster, AreaType.Cage);
                    if (areaId != 0)
                    {
                        activityLogService.Add(
                            new ActivityLog
                            {
                                HamsterId = hamster.Id,
                                ActivityId = (int)ActivityEnum.Arrived,
                                StartTime = Tick.simulatorDate,
                                EndTime = Tick.simulatorDate
                            });

                        activityLogService.Add(
                            new ActivityLog
                            {
                                HamsterId = hamster.Id,
                                ActivityId = (int)ActivityEnum.Cage,
                                AreaId = areaId,
                                StartTime = Tick.simulatorDate
                            });
                        ChangeAreaStatus(areaId);
                    }
                }
            }
        }
        public void CheckOut()
        {
            if (Tick.simulatorDate.Hour == 17)
            {
                var hamsterList = hamsterService.GetAll();
                foreach (var hamster in hamsterList)
                {
                    var lastActivity = hamster.ActivityLogs.Last();
                    lastActivity.EndTime = Tick.simulatorDate;
                    activityLogService.Update(lastActivity);

                    activityLogService.Add(
                            new ActivityLog
                            {
                                HamsterId = hamster.Id,
                                ActivityId = (int)ActivityEnum.Left,
                                StartTime = Tick.simulatorDate,
                                EndTime = Tick.simulatorDate
                            });
                }
                var areas = areaService.GetAll();
                foreach (var area in areas)
                {
                    area.StatusId = (int)Status.Available;
                    areaService.Update(area);
                }
            }
        }
        public void MoveHamster(Hamster hamster, ActivityLog activityLog, ActivityEnum activityEnum, AreaType areaType)
        {
            int areaId = GetAreaId(hamster, areaType);
            if (areaId != 0)
            {
                activityLog.EndTime = Tick.simulatorDate;

                activityLogService.Update(activityLog);

                activityLogService.Add(
                  new ActivityLog
                  {
                      HamsterId = hamster.Id,
                      ActivityId = (int)activityEnum,
                      AreaId = areaId,
                      StartTime = Tick.simulatorDate,
                  });
                ChangeAreaStatus(Convert.ToInt32(activityLog.AreaId));
                ChangeAreaStatus(areaId);
            }
        }
        public void CheckHamsterOnExerciseArea()
        {
            var activityLogs = activityLogService
                .GetById(a => a.ActivityId == (int)ActivityEnum.Exercise)
                .Where(e => e.EndTime == null);

            foreach (var activityLog in activityLogs)
            {
                var startTime = activityLog.StartTime;
                if ((Tick.simulatorDate.TimeOfDay - startTime.Value.TimeOfDay).TotalMinutes > 60)
                {
                    Hamster hamster = hamsterService.GetById(activityLog.HamsterId);
                    MoveHamster(hamster, activityLog, ActivityEnum.Cage, AreaType.Cage);
                }
            }
        }
        public void CheckHamsterOnCageArea()
        {
            var activityLogs = activityLogService
                .GetById(a => a.ActivityId == (int)ActivityEnum.Cage)
                .Where(e => e.EndTime == null).OrderBy(s => s.StartTime).ToList();

            int capacity = areaService.GetById(a => a.AreaTypeId == (int)AreaType.Exercise).Capacity;

            for (int i = 0; i < capacity; i++)
            {
                Hamster hamster = hamsterService.GetById(activityLogs[i].HamsterId);
                MoveHamster(hamster, activityLogs[i], ActivityEnum.Exercise, AreaType.Exercise);
            }
        }
        public int GetAreaId(Hamster hamster, AreaType areaType)
        {
            var areas = areaService.GetByAreaType((int)areaType);
            foreach (var area in areas)
            {
                var logs = area.ActivityLogs.Where(a => a.EndTime == null).ToList();
                if (logs.Count == 0)
                {
                    return area.Id;
                }
                if (logs.Count < area.Capacity
                    && hamsterService.GetById(logs.Last().HamsterId).Gender == hamster.Gender)
                {
                    return area.Id;
                }
            }
            return 0;
        }
        public void ChangeAreaStatus(int areaId)
        {
            var area = areaService.GetById(a=>a.Id == areaId);
            if (area.ActivityLogs.Select(a => a.EndTime == null).Count() == area.Capacity)
            {
                area.StatusId = (int)Status.Unavailable;
            }
            if (area.ActivityLogs.Select(a => a.EndTime == null).Count() < area.Capacity)
            {
                area.StatusId = (int)Status.Available;
            }
        }
    }
}