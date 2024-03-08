using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 2)]
public class Quest : ScriptableObject
{
    public enum QuestType { Transport, Good, Neutral, Evil }
    [SerializeField] public QuestType questType;
    [SerializeField] public NPC targetNPC;
    [SerializeField] public string description;
}
