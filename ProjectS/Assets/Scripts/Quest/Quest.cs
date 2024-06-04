using System;
using UnityEngine;

[Serializable]
public class Quest{
    public int id;
    public string Title;
    public string Description;
    public int Reward;
    [SerializeField] QuestObjective[] objectives;

    public event Action OnQuestComplete;
    public event Action OnQuestUpdated;

    public void OnObjectiveComplete(){
        bool allComplete = true;
        foreach (var questObjective in objectives){
            if (!questObjective.IsComplete){
                allComplete = false;
                break;
            }
        }

        if (allComplete){
            OnQuestComplete?.Invoke();
        }
        else{
            OnQuestUpdated?.Invoke();
        }
    }

    public void StartQuest(){
        foreach (var questObjective in objectives){
            questObjective.OnStart();
            questObjective.OnObjectiveComplete += OnObjectiveComplete;
        }
    }
}