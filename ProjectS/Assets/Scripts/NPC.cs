using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] public string npcName; 
    [SerializeField] public NPCData npcData;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered the trigger");
        if(!other.CompareTag("Player"))
        {
            return;
        }
        GameManager.Instance.SetActiveNPC(this);
    }
    
    void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }
        GameManager.Instance.DialogManager.HideUI();
        GameManager.Instance.SetActiveNPC(null);
    }
}
