using Business.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    public class Tick
    {
        public Tick(int tickPerSecond, int simulationsDay)
        {
            this.tickPerSecond = tickPerSecond * 100;
            this.simulationsDay = simulationsDay * 100;
            simulatorDate = GetDateTime();
            TimeHandler = new Notify(OnTimerEvent);
            StartSimulation();
        }
        Simulator simulator = new Simulator();
        private event Notify TimeHandler;
        public delegate void Notify();
        public int tickPerSecond { get; set; }
        public int simulationsDay { get; set; }
        public static DateTime simulatorDate { get; set; }
        public int TickCount { get; set; }
        public void StartSimulation()
        {
            while (simulationsDay > 0)
            {
                if (simulationsDay % 100 == 0)
                {
                    simulator.CheckIn();
                }
                simulatorDate = simulatorDate.AddMinutes(6);
                TimeHandler.Invoke();
                Thread.Sleep(tickPerSecond);
                Console.WriteLine(simulationsDay);
                Console.WriteLine(simulatorDate.ToString());

                simulationsDay--;
                if (simulatorDate.Hour == 17)
                {
                    simulatorDate = GetDateTime();
                }
            }
        }
        private void OnTimerEvent()
        {

            Task t4 = Task.Run(() => simulator.CheckIn());
            t4.Wait();

            if (simulatorDate.Hour != 17)
            {
                Task t2 = Task.Run(() => simulator.CheckHamsterOnExerciseArea());
                Task t1 = Task.Run(() => simulator.CheckHamsterOnCageArea());
                Task.WaitAll(t2, t1);

            }
            Task t3 = Task.Run(() => simulator.CheckOut()).ContinueWith(task => { simulator.DailyReport(); });
            
            Task.WaitAll(t3);
        }
        private DateTime GetDateTime()
        {
            ActivityLogService activityLogService = new ActivityLogService();
            var activityLogs = activityLogService.GetById(a => a.ActivityId == (int)ActivityEnum.Arrived).OrderBy(x=>x.StartTime).ToList();
            if (activityLogs.Count == 0)
            {
                return new DateTime(2022, 01, 01, 07, 00, 00);
            }
            var lastStartTime = activityLogs.Last().StartTime;
            lastStartTime = lastStartTime.Value.AddDays(1);
            return new DateTime(lastStartTime.Value.Year, lastStartTime.Value.Month, lastStartTime.Value.Day, 07, 00, 00);
        }
    }

}
