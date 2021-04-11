using Business.Service;
using System;
using Entities;
using System.Linq;

namespace Business
{
    public enum ActivityType
    {
        Null = 0,
        Arrived = 1,
        Exercise = 2,
        Cage = 3,
        Left = 4,
        Spa = 5
    }
    public enum AreaType
    {
        Null = 0,
        Cage = 1,
        Exercise = 2,
        Spa = 3
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
        public void CheckIn(int simulationsDay)
        {
            if (simulationsDay % 100 == 0)
            {
                var hamsterList = hamsterService.GetAll();
                var checkInDate = Tick.simulatorDate.Add(new TimeSpan(0,-6,0));
                foreach (var hamster in hamsterList)
                {
                    int areaId = GetAreaId(hamster, AreaType.Cage);
                    if (areaId != 0)
                    {
                        activityLogService.Add(
                            new ActivityLog
                            {
                                HamsterId = hamster.Id,
                                ActivityId = (int)ActivityType.Arrived,
                                StartTime = checkInDate,
                                EndTime = checkInDate
                            });

                        activityLogService.Add(
                            new ActivityLog
                            {
                                HamsterId = hamster.Id,
                                ActivityId = (int)ActivityType.Cage,
                                AreaId = areaId,
                                StartTime = checkInDate
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
                                ActivityId = (int)ActivityType.Left,
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
        public void MoveHamster(Hamster hamster, ActivityLog activityLog, ActivityType activityType, AreaType areaType)
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
                      ActivityId = (int)activityType,
                      AreaId = areaId,
                      StartTime = Tick.simulatorDate,
                  });
                ChangeAreaStatus(Convert.ToInt32(activityLog.AreaId));
                ChangeAreaStatus(areaId);
            }
        }
        public void CheckHamsterOnExerciseArea()
        {
            if (Tick.simulatorDate.Hour != 17)
            {
                var activityLogs = activityLogService
                .GetById(a => a.ActivityId == (int)ActivityType.Exercise)
                .Where(e => e.EndTime == null);

                foreach (var activityLog in activityLogs)
                {
                    var startTime = activityLog.StartTime;
                    if ((Tick.simulatorDate.TimeOfDay - startTime.Value.TimeOfDay).TotalMinutes > 60)
                    {
                        Hamster hamster = hamsterService.GetById(activityLog.HamsterId);
                        MoveHamster(hamster, activityLog, ActivityType.Spa, AreaType.Spa);
                    }
                }
            }
        }
        public void CheckHamsterOnCageArea()
        {
            if (Tick.simulatorDate.Hour != 17)
            {
                var activityLogs = activityLogService
                .GetById(a => a.ActivityId == (int)ActivityType.Cage)
                .Where(e => e.EndTime == null).OrderBy(s => s.StartTime).ToList();

                int capacity = areaService.GetById(a => a.AreaTypeId == (int)AreaType.Exercise).Capacity;

                for (int i = 0; i < capacity; i++)
                {
                    Hamster hamster = hamsterService.GetById(activityLogs[i].HamsterId);
                    MoveHamster(hamster, activityLogs[i], ActivityType.Exercise, AreaType.Exercise);
                }
            }
        }
        public void CheckHamsterOnSpaArea()
        {
            if (Tick.simulatorDate.Hour != 17)
            {
                var activityLogs = activityLogService
                .GetById(a => a.ActivityId == (int)ActivityType.Spa)
                .Where(e => e.EndTime == null);

                foreach (var activityLog in activityLogs)
                {
                    var startTime = activityLog.StartTime;
                    if ((Tick.simulatorDate.TimeOfDay - startTime.Value.TimeOfDay).TotalMinutes > 10)
                    {
                        Hamster hamster = hamsterService.GetById(activityLog.HamsterId);
                        MoveHamster(hamster, activityLog, ActivityType.Cage, AreaType.Cage);
                    }
                }
            }
        }
        public void DailyReport()
        {
            if (Tick.simulatorDate.Hour == 17)
            {
                var hamsters = hamsterService.GetAll();
                TimeSpan totalTime = new TimeSpan();
                Console.WriteLine("Report from {0}", Tick.simulatorDate.Date);
                Console.WriteLine("---------------------------------&&&&&---------------------------------");
                foreach (var hamster in hamsters)
                {
                    var result = hamster.ActivityLogs
                                .Where(x => x.StartTime.Value.Day == Tick.simulatorDate.Day && x.ActivityId != 1 && x.ActivityId != 4)
                                .Select(x => new { ActivityId = x.ActivityId, TotalTime = (x.EndTime - x.StartTime) })
                                .GroupBy(x => new { x.ActivityId }).ToList();

                    Console.WriteLine("Id: {0} / Hamster Name: {1} / Owner Name: {2}", hamster.Id, hamster.Name, hamster.OwnerFullName);

                    foreach (var activity in result)
                    {
                        Console.WriteLine("  ---Activity Name: {0}", (ActivityType)Enum.ToObject(typeof(ActivityType), activity.Key.ActivityId));

                        foreach (var activityTime in activity)
                        {
                            totalTime = (TimeSpan)(totalTime + activityTime.TotalTime);
                        }
                        Console.WriteLine("    --Total time spent during activity: {0}", totalTime);
                        totalTime = new TimeSpan();

                    }
                    var totalExercise = hamster.ActivityLogs.Where(x => x.ActivityId == (int)ActivityType.Exercise && x.StartTime.Value.Day == Tick.simulatorDate.Day);
                    var totalSpa = hamster.ActivityLogs.Where(x => x.ActivityId == (int)ActivityType.Spa && x.StartTime.Value.Day == Tick.simulatorDate.Day);

                    Console.WriteLine("    --Total exercise: {0}", totalExercise.Count());
                    Console.WriteLine("    --Total Spa: {0}", totalSpa.Count());

                    Console.WriteLine("---------------------------------&&&&&---------------------------------");
                };
                Console.ReadLine();
            };
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
            var area = areaService.GetById(a => a.Id == areaId);
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
