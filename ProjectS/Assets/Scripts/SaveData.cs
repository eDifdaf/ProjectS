using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum ERadioStations{
    None,
    Erwin,
    Hotradio,
    Beachwave,
    ClassicFm,
}
public enum EPlayerColor{
    Red,
    Blue,
    Green,
    Yellow,
    Purple,
    Orange,
    Pink,
    Black,
    White,

} 
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

    public struct PlayerData{
        public Vector3 position;
        public Quaternion rotation;
        public bool onBike;
        public int money;
        public ERadioStations currentRadio;
    }

    public struct UnlocksData{
        public BikeData bike;
        public GarageData garage;
        public List<bool> unlockedRadios;

        public struct BikeData{
            public EPlayerColor color;
            public GearData gear;

            public struct GearData{
                public float speed;
                public float acceleration;
            }
        }

        public struct GarageData{
            public List<bool> trophies;
            public List<bool> cosmetic;
        }
    }

    public struct QuestsData{
        public List<Quest> activeQuests;
        public List<Quest> completedQuests;
    }
}