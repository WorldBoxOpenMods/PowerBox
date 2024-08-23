using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerBox.Code.LoadingSystem {
  public class FeatureRequirementList : IEnumerable<Type> {
    private List<Type> RequiredFeatureList { get; } = new List<Type>();
    public FeatureRequirementList(params Type[] types) {
      RequiredFeatureList.AddRange(types);
    }
    public static FeatureRequirementList operator +(FeatureRequirementList list, Type type) {
      return list.RequiredFeatureList.Append(type).ToList();
    }
    public static implicit operator FeatureRequirementList(List<Type> list) => new FeatureRequirementList(list.ToArray());
    public static implicit operator List<Type>(FeatureRequirementList list) => list.RequiredFeatureList;
    public static implicit operator FeatureRequirementList(Type type) => new FeatureRequirementList(type);
    public IEnumerator<Type> GetEnumerator() => RequiredFeatureList.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
  }
}
