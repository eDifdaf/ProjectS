using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCData", menuName = "ScriptableObjects/NPCData", order = 1)]
public class NPCData : ScriptableObject
{
    [SerializeField] public List<NPC> friends;
    [SerializeField] public List<NPC> enemies;
    [SerializeField] public List<Quest> quests;
    [SerializeField] public string story;
    [SerializeField] public List<string> greetings;
    [SerializeField] public List<string> goodbyes;
    public enum TimeOfDay { Morning, Noon, Afternoon, Evening, Night }
    [SerializeField] public TimeOfDay timeOfDay;
    
}

