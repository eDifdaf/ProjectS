using System.Collections.Generic;
using UnityEngine;

public class CollectAndReturnQuest : QuestObjective
{
    public List<GameObject> objectsToCollect;
    private List<GameObject> collectedObjects = new List<GameObject>();
    private NPC _questnpc;

    public override void OnStart()
    {
        base.OnStart();
        _questnpc = GameObject.Find("Player").GetComponent<PlayerController>().npc;
        _questnpc.UpdateQuestState();
        foreach (var obj in objectsToCollect)
        {
            obj.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!IsActive){
            return;
        }
        if (objectsToCollect.Contains(other.gameObject))
        {
            other.gameObject.SetActive(false);
            objectsToCollect.Remove(other.gameObject);
            collectedObjects.Add(other.gameObject);
        }
        else if (collectedObjects.Contains(other.gameObject))
        {
            other.gameObject.SetActive(true);
            collectedObjects.Remove(other.gameObject);

            if (collectedObjects.Count == 0)
            {
                CompleteObjective();
            }
        }
    }
    public override void OnAfterComplete(){
        base.OnAfterComplete();
        _questnpc.UpdateQuestState();
    }
}