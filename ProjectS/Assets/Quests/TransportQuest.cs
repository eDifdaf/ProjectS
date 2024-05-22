using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportQuest : QuestObjective{
    private void OnTriggerEnter(Collider other){
        CompleteObjective();
    }
}