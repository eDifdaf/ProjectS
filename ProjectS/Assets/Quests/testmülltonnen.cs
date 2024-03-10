using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmülltonnen : QuestObjective {
    private readonly List<Vector3> initalPos = new();
    private readonly List<Quaternion> initalRot = new(); 

    private readonly List<Transform> trashcans = new();

    //every trashcan that is currently in the gameobject will be added to the list
    private void Start() {
        foreach (Transform child in transform) {
            initalRot.Add(child.rotation);
            initalPos.Add(child.position);
            trashcans.Add(child);
        }
    }

    private void Update() {
        for (var i = 0; i < trashcans.Count; i++) {
            var can = trashcans[i];
            if (can.position == initalPos[i]) return;
        }
        CompleteObjective();
    }

    public override void OnAfterComplete() {
        
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player") && IsComplete){
            StartCoroutine(DelayedReset());
        }
    }

    IEnumerator DelayedReset() {
        yield return new WaitForSeconds(2);
        for (var index = 0; index < trashcans.Count; index++) {
            var trashcan = trashcans[index];
            trashcan.position = initalPos[index];
            trashcan.rotation = initalRot[index];
        }
    }
}