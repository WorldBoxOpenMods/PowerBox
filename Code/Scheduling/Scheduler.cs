using System;
using System.Collections.Generic;

namespace PowerBox.Code.Scheduling {
  public class Scheduler {
    private static Scheduler _instance;
    private readonly List<Schedule> _schedules = new List<Schedule>();
    private Scheduler() { }
    public static Scheduler Instance => _instance ?? (_instance = new Scheduler());
    public void Schedule(Schedule schedule) {
      _schedules.Add(schedule);
    }
    public void Run() {
      foreach (Schedule schedule in _schedules.ToArray()) {
        int maxBlockingTime = schedule.MaxBlockingTime;
        Action nextStep;
        int startTime = Environment.TickCount;
        do {
          nextStep = schedule.GetNextStep();
          if (nextStep != null) {
            nextStep.Invoke();
          } else {
            _schedules.Remove(schedule);
          }
        } while (Environment.TickCount - startTime < maxBlockingTime && nextStep != null);
      }
    }
  }
}
