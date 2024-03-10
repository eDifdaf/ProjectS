using System;
using UnityEngine;

[Serializable] public class Quest
{
    [SerializeField] int ID;
    [SerializeField] string Title;
    [SerializeField] string Description;
    [SerializeField] Collider targetLocation;
    [SerializeField] QuestObjective[] objectives;
    [SerializeField] NPC questGiver;
}
