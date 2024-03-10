using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MainQuest", menuName = "ScriptableObjects/Quest/MainQuest", order = 2)]
public class MainQuest : Quest {
    public enum QuestType {
        Good,
        Neutral,
        Evil
    }
    public QuestType questType;
    public GameObject target;
}
