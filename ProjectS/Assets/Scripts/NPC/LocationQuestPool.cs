using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class LocationQuestPool
{
    [SerializeField] private List<Quest> quests;
    public Collider location;
    public NPCData.TimeOfDay timeOfDay;
}
