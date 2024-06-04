using UnityEngine;

public class TransportQuest : QuestObjective{
    private NPC _questnpc;
    private Vector3 _newPosition;
    private Transform npcHolder;
    public override void OnStart(){
        base.OnStart();
        _questnpc = GetComponent<PlayerController>().npc;
        _questnpc.UpdateQuestState();
        npcHolder = GameObject.Find("NPCholder").transform;
        _questnpc.transform.SetParent(npcHolder);
        _questnpc.transform.position = new Vector3(0,0,0);
    }
    private void OnTriggerEnter(Collider other){
        _newPosition = other.transform.position;
        CompleteObjective();
    }

    public override void OnAfterComplete(){
        base.OnAfterComplete();
        _questnpc.UpdateQuestState();
        _questnpc.transform.SetParent(GameObject.Find("all_NPC").transform);
        _questnpc.transform.position = _newPosition;
    }
}