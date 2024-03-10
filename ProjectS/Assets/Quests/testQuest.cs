using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class testQuest : QuestObjective
{
    private void OnTriggerEnter(Collider other) {
        CompleteObjective();
    }
    
}
