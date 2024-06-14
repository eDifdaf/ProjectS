using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrades : MonoBehaviour{
    public bool inRange;
    
    
    public void Upgrade(){
        
    }
    
    
    private void OnTriggerEnter(Collider other){
        if (!other.CompareTag("Player")){
            return;
        }
        GetComponent<SpriteRenderer>().enabled = true;
        inRange = true;
    }

    void OnTriggerExit(Collider other){
        if (!other.CompareTag("Player")){
            return;
        }
        GetComponent<SpriteRenderer>().enabled = true;
        inRange = false;
    }
}
