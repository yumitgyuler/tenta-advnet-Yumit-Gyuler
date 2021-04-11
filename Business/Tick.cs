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
            this.tickPerSecond = 1000 / tickPerSecond;
            this.simulationsDay = simulationsDay * 100;
            simulatorDate = GetDateTime();
            TimeHandler = new Notify(OnTimerEvent);
            StartSimulation();
        }

        Simulator simulator = new Simulator();
        ActivityLogService activityLogService = new ActivityLogService();

        private event Notify TimeHandler;
        public delegate void Notify();

        public int tickPerSecond { get; set; }
        public int simulationsDay { get; set; }
        public static DateTime simulatorDate { get; set; }
        
        public void StartSimulation()
        {
            while (simulationsDay > 0)
            {
                Console.WriteLine(simulatorDate.ToString());

                simulatorDate = simulatorDate.AddMinutes(6);

                TimeHandler.Invoke();
                Thread.Sleep(tickPerSecond);

                simulationsDay--;
                if (simulatorDate.Hour == 17)
                {
                    simulatorDate = GetDateTime();
                }
            }
        }
        private void OnTimerEvent()
        {
            Task t4 = Task.Run(() => simulator.CheckIn(simulationsDay));
            t4.Wait();

            Task t2 = Task.Run(() => simulator.CheckHamsterOnExerciseArea());
            Task t5 = Task.Run(() => simulator.CheckHamsterOnSpaArea());
            Task t1 = Task.Run(() => simulator.CheckHamsterOnCageArea());

            Task t3 = Task.Run(() => simulator.CheckOut()).ContinueWith(task => { simulator.DailyReport(); });
            t3.Wait();
        }
        private DateTime GetDateTime()
        {
            var activityLogs = activityLogService.GetById(a => a.ActivityId == (int)ActivityType.Arrived).OrderBy(x => x.StartTime).ToList();
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
