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
    
    
    public void SaveGame()
    {
        SaveData saveData = new SaveData();
        
        //player data
        saveData.player.position = playerTransform.transform.position;
        saveData.player.rotation = playerTransform.transform.rotation;
        saveData.player.money = GameManager.Instance.Playermanager.player.GetComponent<Currency>().CurrentcyCount;
        saveData.player.currentRadio = ERadioStations.None;
        
        saveData.unlocksData.bike.color = EPlayerColor.Red;
        //ahhhhhhh wo ist das 
        saveData.unlocksData.bike.gear.acceleration = 0;
        saveData.unlocksData.bike.gear.speed = 0;
        
        //haben wir nicht, geil
        saveData.unlocksData.garage.trophies = new List<bool>();
        saveData.unlocksData.garage.cosmetic = new List<bool>();
        
        //eben so
        saveData.unlocksData.unlockedRadios = new List<bool>();
        
        saveData.questsData.activeQuests = GameManager.Instance.QuestManager.currentQuest;
        saveData.questsData.completedQuests = GameManager.Instance.Playermanager.LcompletedQuests;
        
        string playerJS = JsonUtility.ToJson(saveData.player);
        string unlockJS = JsonUtility.ToJson(saveData.unlocksData);
        string questJS = JsonUtility.ToJson(saveData.questsData);


        string json = "{\n \"player\" : " + playerJS + ", \n \"unlocks\" : " + unlockJS + ", \n \"quests\" : " + questJS + " \n}";
        int checksum = json.GetHashCode();
        json += "\n" + checksum;
        
        System.IO.File.WriteAllText(Application.persistentDataPath + "/save.json", json);
        Debug.Log(Application.persistentDataPath + "/save.json");
        
    }
    public void LoadGame(){
        //TODO: playercanmoveaddpls playerTransform.GetComponent<PlayerController>().playerCanMove = false;
        string json = System.IO.File.ReadAllText(Application.persistentDataPath + "/save.json");
        int checksum = int.Parse(json.Substring(json.LastIndexOf('\n') + 1));
        json = json.Substring(0, json.LastIndexOf('\n'));

        if (checksum != json.GetHashCode())
        {
            Debug.LogError("Save file is corrupted");
            return;
        }
        GameManager.Instance.player.GetComponent<PlayerController>().enabled = false;
        GameManager.Instance.player.GetComponent<PlayerMotor>().enabled = false;
        playerTransform.GetComponent<PlayerController>();
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);

        playerTransform.transform.position = saveData.player.position;
        playerTransform.transform.rotation = saveData.player.rotation;
        GameManager.Instance.QuestManager.AssignQuests(saveData.questsData.activeQuests);
        GameManager.Instance.Playermanager.Init();
        GameManager.Instance.Playermanager.LcompletedQuests = saveData.questsData.completedQuests;
        for (int i = 0; i < GameManager.Instance.Playermanager.LcompletedQuests.Count; i++){
            GameManager.Instance.Playermanager.DcompletedQuests.Add(i, GameManager.Instance.Playermanager.LcompletedQuests[i]);
        }
        
        
        
        
        
        GameManager.Instance.player.GetComponent<PlayerController>().enabled = true;
        GameManager.Instance.player.GetComponent<PlayerMotor>().enabled = true;
    }
}