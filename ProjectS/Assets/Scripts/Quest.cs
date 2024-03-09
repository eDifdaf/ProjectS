using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 2)]
public class Quest : ScriptableObject
{
    [SerializeField] public NPC targetNPC;
    [SerializeField] public string description;
}
