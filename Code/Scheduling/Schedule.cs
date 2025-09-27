using System;
using System.Collections.Generic;

namespace PowerBox.Code.Scheduling {
  public class Schedule {
    private readonly List<Action> _actions = new List<Action>();
    public Schedule(int maxBlockingTime, params Action[] actions) {
      MaxBlockingTime = maxBlockingTime;
      _actions.AddRange(actions);
    }
    public int MaxBlockingTime { get; private set; }
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
