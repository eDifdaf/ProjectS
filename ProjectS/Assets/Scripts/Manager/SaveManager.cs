using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private GameObject playerTransform;
    public void Update(){
        if (Input.GetKeyDown(KeyCode.I)){
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.O)){
            LoadGame();
        }
    }
    
    
    private void SaveGame()
    {
        SaveData saveData = new SaveData();
        
        //player data
        saveData.player.position = playerTransform.transform.position;
        saveData.player.rotation = playerTransform.transform.rotation;
        /*saveData.player.onBike = false;
        saveData.player.money = 0;
        saveData.player.currentRadio = ERadioStations.None;
        
        saveData.unlocksData.bike.color = EPlayerColor.Red;
        saveData.unlocksData.bike.gear.acceleration = 0;
        saveData.unlocksData.bike.gear.speed = 0;
        
        saveData.unlocksData.garage.trophies = new List<bool>();
        saveData.unlocksData.garage.cosmetic = new List<bool>();
        
        saveData.unlocksData.unlockedRadios = new List<bool>();
        
        
        saveData.questsData.activeQuests = new List<Quest>();
        saveData.questsData.completedQuests = new List<Quest>();
        Debug.Log(saveData.ToString());*/
        
        //write those as json save file
        string playerJS = JsonUtility.ToJson(saveData.player);
        string unlockJS = JsonUtility.ToJson(saveData.unlocksData);
        string questJS = JsonUtility.ToJson(saveData.questsData);


        string json = "{\n \"player\" : " + playerJS + ", \n \"unlocks\" : " + unlockJS + ", \n \"quests\" : " + questJS + " \n}";
        int checksum = json.GetHashCode();
        //json += "\n" + checksum;
        
        System.IO.File.WriteAllText(Application.persistentDataPath + "/save.json", json);
        Debug.Log(Application.persistentDataPath + "/save.json");
        
    }
    public void LoadGame()
    {
        string json = System.IO.File.ReadAllText(Application.persistentDataPath + "/save.json");
        int checksum = int.Parse(json.Substring(json.LastIndexOf('\n') + 1));
        json = json.Substring(0, json.LastIndexOf('\n'));

        if (checksum != json.GetHashCode())
        {
            Debug.LogError("Save file is corrupted");
            return;
        }

        SaveData saveData = JsonUtility.FromJson<SaveData>(json);

        playerTransform.transform.position = saveData.player.position;
        playerTransform.transform.rotation = saveData.player.rotation;
    }
}