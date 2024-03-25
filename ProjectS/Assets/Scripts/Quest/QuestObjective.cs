using System;
using UnityEngine;

public abstract class QuestObjective : MonoBehaviour {
    public event Action OnObjectiveComplete;
    public bool IsComplete { get; protected set; }
    public virtual void OnStart() {
        IsComplete = false;
    }

    public virtual void OnAfterComplete() {
    }
    public void CompleteObjective() {
        IsComplete = true;
        OnAfterComplete();
        OnObjectiveComplete?.Invoke();
        OnObjectiveComplete = null;
    }
}