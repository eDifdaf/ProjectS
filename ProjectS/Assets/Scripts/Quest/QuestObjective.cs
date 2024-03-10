using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class QuestObjective : MonoBehaviour {
    public event Action OnObjectiveComplete;
    public bool IsComplete { get; protected set; }
    public virtual void OnStart() {
        this.gameObject.SetActive(true);
    }

    public virtual void OnAfterComplete() {
        this.gameObject.SetActive(false);
    }
    public void CompleteObjective() {
        IsComplete = true;
        OnAfterComplete();
        OnObjectiveComplete?.Invoke();
        OnObjectiveComplete = null;
    }
}