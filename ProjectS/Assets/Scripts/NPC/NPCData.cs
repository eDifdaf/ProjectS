using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCData", menuName = "ScriptableObjects/NPCData", order = 1)]
public class NPCData : ScriptableObject {
    [SerializeField] private List<NPC> friends;
    [SerializeField] private List<NPC> enemies;
    [SerializeField] private List<Quest> quests;
    public string story;
    public List<string> greetings;
    public List<string> goodbyes;
    public enum TimeOfDay { Morning, Noon, Afternoon, Evening, Night }
    [SerializeField] public TimeOfDay timeOfDay;
}