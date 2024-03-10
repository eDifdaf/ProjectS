using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TransportQuest", menuName = "ScriptableObjects/Quest/TransportQuest", order = 2)]
public class TransportQuest : Quest
{
    public GameObject targetLocation;
    public GameObject startLocation;
}