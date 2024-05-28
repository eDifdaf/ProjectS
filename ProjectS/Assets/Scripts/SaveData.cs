using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[System.Serializable]
public class SaveData{
    public PlayerData player;
    public UnlocksData unlocksData;
    public QuestsData questsData;

    public SaveData(){
        player = new PlayerData();
        unlocksData = new UnlocksData();
        questsData = new QuestsData();
    }

    [System.Serializable]
    public struct PlayerData{
        public Vector3 position;
        public Quaternion rotation;
        public bool onBike;
        public int money;
        public ERadioStations currentRadio;
    }

    [System.Serializable]
    public struct UnlocksData{
        public BikeData bike;
        public GarageData garage;
        public List<bool> unlockedRadios;

        [System.Serializable]
        public struct BikeData{
            public EPlayerColor color;
            public GearData gear;

            [System.Serializable]
            public struct GearData{
                //TODO: finally have the bike stats
                public float speed;
                public float acceleration;
            }
        }

        [System.Serializable]
        public struct GarageData{
            //TODO: implement garage stuff
            public List<bool> trophies;
            public List<bool> cosmetic;
        }
    }

    [System.Serializable]
    public struct QuestsData{
        public Quest activeQuests;
        public List<bool> completedQuests;
    }
}
