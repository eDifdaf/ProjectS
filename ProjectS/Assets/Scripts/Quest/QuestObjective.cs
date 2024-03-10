using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class QuestObjective : MonoBehaviour {
    public abstract void OnStart();

    public virtual void OnComplete() {
        //TODO call even that its completed
    }
}
