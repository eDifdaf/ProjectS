using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermanager : MonoBehaviour
{
    public List<string> LallQuests;
    public Dictionary<int, bool> DcompletedQuests;
    public List<bool> LcompletedQuests;
    
    public void Init(){
        LallQuests = new List<string>(32);
        DcompletedQuests = new Dictionary<int, bool>(32);
        LcompletedQuests = new List<bool>(32);
    }
}
