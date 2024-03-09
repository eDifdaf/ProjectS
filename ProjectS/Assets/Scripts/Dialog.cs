using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using UnityEngine.UIElements;

public class Dialog : MonoBehaviour
{
    public Canvas dialogCanvas;
    public UnityEngine.UI.Button button1;
    public UnityEngine.UI.Button button2;
    public UnityEngine.UI.Button button3;
    private TMP_Text bt1Text;
    private TMP_Text bt2Text;
    private TMP_Text bt3Text;
    public List<string> greetings;
    public List<string> goodbyes;
    
    
    public float delay = 0.1f;
    private string currentText = "";
    void Start()
    {
        //get the greetings and goodbyes from the npc script that is also attached to this gameobject
        greetings = GetComponent<NPC>().npcData.greetings;
        goodbyes = GetComponent<NPC>().npcData.goodbyes;
        //get me the child text element of the buttons
        bt1Text = button1.GetComponentInChildren<TMP_Text>();
        bt2Text = button2.GetComponentInChildren<TMP_Text>();
        bt3Text = button3.GetComponentInChildren<TMP_Text>();
        dialogCanvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered the trigger");
        if(other.tag != "Player")
        {
            return;
        }
        dialogCanvas.enabled = true;
        StartCoroutine(ShowText(greetings[0]));
        
        StartCoroutine(ShowText("What would you like to do?"));
        
        bt1Text.text = "Give me a quest";
        bt2Text.text = "Tell me about yourself";
        bt3Text.text = "Goodbye";

    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag != "Player")
        {
            return;
        }
        dialogCanvas.enabled = false;
    }
    
    IEnumerator ShowText(string fullText)
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i+1);
            dialogCanvas.GetComponentInChildren<TMP_Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
