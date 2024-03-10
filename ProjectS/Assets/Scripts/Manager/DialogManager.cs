using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private NPCData npcData;
    [SerializeField] private GameObject player;
    [SerializeField] private Canvas dialogCanvas;
    [SerializeField] private TMP_Text dialogtext;
    [SerializeField] private List<TMP_Text> _buttons;
    private WaitForSeconds wait = new WaitForSeconds(0.05f);
    public bool IsEnabled => dialogCanvas.enabled;
    public void StartDialog(NPC npc)
    {
        npcData = npc.npcData;
        StartCoroutine(ShowText(npcData.greetings[0]));
        _buttons[0].SetText("Give me a quest");
        _buttons[1].SetText("Tell me about you");
        _buttons[2].SetText("I don't need anything, bye");
    }
    
    public void HideUI()
    {
        dialogCanvas.enabled = false;
        player.GetComponent<basicmovementscript>().enabled = true;
    }
    
    public void ShowUI()
    {
        dialogCanvas.enabled = true;
        player.GetComponent<basicmovementscript>().enabled = false;
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
        GameManager.Instance.DayNightManager.ResumeTime();
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
