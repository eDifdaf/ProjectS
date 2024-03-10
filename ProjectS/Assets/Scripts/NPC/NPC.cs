using System;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] public string npcName; 
    [SerializeField] public NPCData npcData;
    [SerializeField] private SpriteRenderer popup;
    [SerializeField] private LocationQuestPool[] locationQuestPool;
    private bool isPlayerInRange;

    private void Awake() {
        GameManager.Instance.DayNightManager.OnTimeChanged += OnTimeChanged;
        this.gameObject.SetActive(false);
    }

    private void OnTimeChanged(NPCData.TimeOfDay obj) {

        LocationQuestPool newLocation = null;
        foreach (var location in locationQuestPool) {
            if (location.timeOfDay == obj) {
                newLocation = location;
            }
        }

        if (newLocation == null) {
            this.gameObject.SetActive(false);
            return;
        }
        
        this.transform.position = newLocation.location.bounds.center;
        this.gameObject.SetActive(true);



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
        GameManager.Instance.SetActiveNPC(null);
    }

    private void OnDestroy() {
        GameManager.Instance.DayNightManager.OnTimeChanged -= OnTimeChanged;
    }
}
