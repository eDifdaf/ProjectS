using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainQuest : Quest {
    public enum QuestType {
        Good,
        Neutral,
        Evil
    }
    public QuestType questType;
    public GameObject target;
}
