using System;
using UnityEngine;

public abstract class QuestObjective : MonoBehaviour{
    public event Action OnObjectiveComplete;
    public bool IsComplete { get; protected set; }
    public bool IsActive = false;

    public virtual void OnStart(){
        IsComplete = false;
    }

    public virtual void OnAfterComplete(){
        if(GameManager.Instance.QuestManager.currentQuest.rewardIsFish){
            //unlock se fish
        }
        else{
            int amount = GameManager.Instance.QuestManager.currentQuest.Reward;
            GameManager.Instance.player.GetComponent<Currency>().AddCurrency(amount);
        }
    }

    public void CompleteObjective(){
        IsComplete = true;
        OnAfterComplete();
        OnObjectiveComplete?.Invoke();
        OnObjectiveComplete = null;
        IsActive = false;
    }
}