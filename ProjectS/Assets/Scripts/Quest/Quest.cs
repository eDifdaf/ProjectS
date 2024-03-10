using System;
using UnityEngine;

[Serializable] public class Quest
{
    [SerializeField] int id;
    public string Title;
    public string Description;
    [SerializeField] Collider targetLocation;
    [SerializeField] QuestObjective[] objectives;
    [SerializeField] NPC questGiver;

     public event Action OnQuestComplete;
     public event Action OnQuestUpdated;
     
     public void OnObjectiveComplete() {
         bool allComplete = true;
         foreach (var questObjective in objectives) {
             if (!questObjective.IsComplete) {
                 allComplete = false;
                 break;
             }
         }
         if (allComplete) {
             OnQuestComplete?.Invoke();
         }
         else {
             OnQuestUpdated?.Invoke();
         }
     }
     
     public void StartQuest() {
         foreach (var questObjective in objectives) {
             questObjective.OnStart();
             questObjective.OnObjectiveComplete += OnObjectiveComplete;
         }
     }
}
