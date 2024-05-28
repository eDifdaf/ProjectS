using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour{
    public Quest currentQuest;

    public void AssignQuests(Quest quest){
        if (currentQuest == quest){
            return;
        }
        //TODO Check if other quest is active
        //TODO Check if quest is already completed
        quest.StartQuest();
        quest.OnQuestComplete += DebugStuff;
        quest.OnQuestUpdated += UpdateStuff;
        currentQuest = quest;
    }

    private void UpdateStuff(){
        //TODO add to PlayerManager completed quests
        GameManager.Instance.Playermanager.DcompletedQuests[currentQuest.id] = true;
    }

    private void DebugStuff(){
        Debug.Log("Quest Complete");
        currentQuest.OnQuestComplete -= DebugStuff;
        currentQuest.OnQuestUpdated -= UpdateStuff;
    }
}