using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LocationQuestPool{
    public List<Quest> quests;
    public Collider location;
    public List<TimeOfDay> timeOfDay;
}