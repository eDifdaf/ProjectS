using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> availableQuests;
    private List<Quest> completedQuests;

    public void AssignQuests(GameObject player)
    {
        // Hier kannst du Logik hinzufügen, um Quests zufällig aus der Liste der verfügbaren Quests auszuwählen und sie dem NPC zuzuweisen.
        Debug.Log("hi");
    }
}