using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCminimap : MonoBehaviour
{
    public Sprite iconSprite; // Lade dein Bild hier im Unity Editor
    private GameObject icon;

    void Start()
    {
        // Erstelle ein neues GameObject und füge ein SpriteRenderer hinzu
        icon = new GameObject();
        icon.transform.parent = GameObject.Find("MinimapCamera").transform;
        SpriteRenderer sr = icon.AddComponent<SpriteRenderer>();
        sr.sprite = iconSprite;
        icon.layer = 5;
    }

    void Update()
    {
        // Aktualisiere die Position des Icons, um sie mit dem Spieler/NPC zu synchronisieren
        Vector3 iconPosition = Camera.main.WorldToScreenPoint(transform.position);
        icon.transform.position = iconPosition;
    }
}

