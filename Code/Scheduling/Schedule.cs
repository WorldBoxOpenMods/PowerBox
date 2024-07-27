using System;
using System.Collections.Generic;

namespace PowerBox.Code.Scheduling {
  public class Schedule {
    public int MaxBlockingTime { get; private set; }
    private readonly List<Action> _actions = new List<Action>();
    public Schedule(int maxBlockingTime, params Action[] actions) {
      MaxBlockingTime = maxBlockingTime;
      _actions.AddRange(actions);
    }
    public Action GetNextStep() {
      if (_actions.Count == 0) {
        return null;
      }
      Action action = _actions[0];
      _actions.RemoveAt(0);
      return action;
    }
  }
}