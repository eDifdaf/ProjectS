using System;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] public string npcName; 
    [SerializeField] public NPCData npcData;
    [SerializeField] private SpriteRenderer popup;
    private bool isPlayerInRange;

    private void Awake() {
        GameManager.Instance.DayNightManager.OnTimeChanged += OnTimeChanged;
    }

    private void OnTimeChanged(NPCData.TimeOfDay obj) {
        //TODO: spawn NPC
        Debug.Log("Time of day changed to " + obj);
    }

    void Update() {
        
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && GameManager.Instance.DialogManager.IsEnabled == false) {
            GameManager.Instance.SetActiveNPC(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered the trigger");
        if(!other.CompareTag("Player"))
        {
            return;
        }
        popup.enabled = true;
        isPlayerInRange = true;
    }
    
    void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }
        popup.enabled = false;
        isPlayerInRange = false;
        GameManager.Instance.DialogManager.HideUI();
        GameManager.Instance.SetActiveNPC(null);
    }

    private void OnDestroy() {
        GameManager.Instance.DayNightManager.OnTimeChanged -= OnTimeChanged;
    }
}
