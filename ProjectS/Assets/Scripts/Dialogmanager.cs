using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogmanager : MonoBehaviour
{
    private NPCData npcData;
    [SerializeField] private GameObject player;
    [SerializeField] private Canvas dialogCanvas;
    [SerializeField] private TMP_Text dialogtext;
    [SerializeField] private List<Button> _buttons;
    private WaitForSeconds wait = new WaitForSeconds(0.05f);
    private string currentText = "";
    public void StartDialog(NPC npc)
    {
        npcData = npc.npcData;
        StartCoroutine(ShowText(npcData.greetings[0]));
        _buttons[0].GetComponentInChildren<TMP_Text>().SetText("Give me a quest");
        _buttons[1].GetComponentInChildren<TMP_Text>().SetText("Tell me about you");
        _buttons[2].GetComponentInChildren<TMP_Text>().SetText("I don't need anything, bye");
    }
    
    public void HideUI()
    {
        dialogCanvas.enabled = false;
    }
    
    public void ShowUI()
    {
        dialogCanvas.enabled = true;
    }
    
    public void Button1()
    {
        GameManager.Instance.QuestManager.AssignQuests(player);
    }
    
    public void Button2()
    {
        StartCoroutine(ShowText(npcData.story));
    }
    
    public void Button3()
    {
        StartCoroutine(Goodbye(npcData.goodbyes[0]));
    }
    
    IEnumerator Goodbye(string fullText) {
        yield return StartCoroutine(ShowText(fullText));
        yield return new WaitForSeconds(2); //maybe set as variable
        HideUI();
    }
    IEnumerator ShowText(string fullText)
    {
        dialogtext.SetText(fullText);
        
        for (int i = 0; i < fullText.Length; i++)
        {
            dialogtext.maxVisibleCharacters = i+1;
            yield return wait;
        }
    }
}
