using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour{
    private NPC currNPC;
    [SerializeField] private GameObject player;
    [SerializeField] private Canvas dialogCanvas;
    [SerializeField] private TMP_Text dialogtext;
    [SerializeField] private List<TMP_Text> buttons;
    private WaitForSeconds wait = new WaitForSeconds(0.05f);
    public bool IsEnabled => dialogCanvas.enabled;

    public void StartDialog(NPC npc){
        currNPC = npc;
        StartCoroutine(ShowText(currNPC.greetings[0]));
        buttons[0].SetText("Give me a quest");
        buttons[1].SetText("Tell me about you");
        buttons[2].SetText("I don't need anything, bye");
    }

    public void HideUI(){
        dialogCanvas.enabled = false;
        if (player != null){
            player.GetComponent<PlayerController>().enabled = true;
        }
    }

    public void ShowUI(){
        dialogCanvas.enabled = true;
        if (player){
            player.GetComponent<PlayerController>().enabled = false;
        }
    }

    public void Button1(){
        //TODO all location quest pools
        foreach (Quest quest in currNPC.locationQuestPool[0].quests){
            if (GameManager.Instance.Playermanager.LcompletedQuests[quest.id]){
                continue;
            }
            if (GameManager.Instance.QuestManager.currentQuest == quest){
                continue;
            }
            GameManager.Instance.QuestManager.AssignQuests(quest);
            StartCoroutine(ShowText(quest.Description));
            return;
        }
    }

    public void Button2(){
        StartCoroutine(ShowText(currNPC.story));
    }

    public void Button3(){
        int random = Random.Range(0, currNPC.goodbyes.Count);
        StartCoroutine(Goodbye(currNPC.goodbyes[random]));
    }

    IEnumerator Goodbye(string fullText){
        yield return StartCoroutine(ShowText(fullText));
        yield return new WaitForSeconds(2); //maybe set as variable
        HideUI();
        GameManager.Instance.DayNightManager.ResumeTime();
    }

    IEnumerator ShowText(string fullText){
        dialogtext.SetText(fullText);

        for (int i = 0; i < fullText.Length; i++){
            dialogtext.maxVisibleCharacters = i + 1;
            yield return wait;
        }
    }
}