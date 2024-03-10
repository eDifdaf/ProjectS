using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private Quest currentQuest;
    
    public void AssignQuests(Quest quest) {
        quest.StartQuest();
        quest.OnQuestComplete += DebugStuff;
        quest.OnQuestUpdated += UpdateStuff;
        currentQuest = quest;
    }

    private void UpdateStuff() {
        Debug.Log("Quest Updated");
    }

    private void DebugStuff() {
        Debug.Log("Quest Complete");
        currentQuest.OnQuestComplete -= DebugStuff;
        currentQuest.OnQuestUpdated -= UpdateStuff;
    }
}