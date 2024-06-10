using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour
{
    private bool isPlayerInRange;
    [SerializeField] private GameObject player;
    
    
    public void PlayerInteract()
    {
        if (isPlayerInRange && GameManager.Instance.DialogManager.IsEnabled == false) {
            
            //Code the sender should do
            NPC npc = GetComponent<NPC>();
            npc.PlayerInteract();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered the trigger");
        if(!other.CompareTag("Player"))
        {
            return;
        }

        isPlayerInRange = true;


        
        player.GetComponent<PlayerController>().sender = this;

    }
    
    void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }

        isPlayerInRange = false;


        player.GetComponent<PlayerController>().sender = null;
    }

}
