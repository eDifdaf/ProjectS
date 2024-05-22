using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.HighDefinition;

public class DayNightManager : MonoBehaviour{
    [Header("Time Settings")] [Range(0f, 24f)]
    public float currentTimeOfDay;

    public float timeSpeed = 1f;

    [Header("Light Settings")] public Light sunLight;
    public float sunposition = 1f;
    public Light moonLight;
    public float moonposition = 1f;

    [SerializeField] private TMP_Text timeText;
    [SerializeField] private Image uiImage;
    public event Action<NPCData.TimeOfDay> OnTimeChanged;
    private NPCData.TimeOfDay currentTime;
    public bool isPaused;

    public void PauseTime(){
        isPaused = true;
    }

    public void ResumeTime(){
        isPaused = false;
    }

    private void Update(){
        if (isPaused){
            return;
        }

        currentTimeOfDay += Time.deltaTime * timeSpeed;
        if (currentTimeOfDay >= 24.0f){
            currentTimeOfDay = 0.0f;
        }

        UpdateNPCs();
        UpdateLight();
    }

    private void UpdateNPCs(){
        if (currentTimeOfDay >= 6.0f && currentTimeOfDay < 12.0f && currentTime != NPCData.TimeOfDay.Morning){
            currentTime = NPCData.TimeOfDay.Morning;
            OnTimeChanged?.Invoke(currentTime);
            Debug.Log("Morning");
        }
        else if (currentTimeOfDay >= 12.0f && currentTimeOfDay < 18.0f && currentTime != NPCData.TimeOfDay.Afternoon){
            currentTime = NPCData.TimeOfDay.Afternoon;
            OnTimeChanged?.Invoke(currentTime);
            Debug.Log("Afternoon");
        }
        else if (currentTimeOfDay >= 18.0f && currentTimeOfDay < 24.0f && currentTime != NPCData.TimeOfDay.Evening){
            currentTime = NPCData.TimeOfDay.Evening;
            OnTimeChanged?.Invoke(currentTime);
            Debug.Log("Evening");
        }
        else if (currentTimeOfDay >= 0f && currentTimeOfDay < 6.0f && currentTime != NPCData.TimeOfDay.Night){
            currentTime = NPCData.TimeOfDay.Night;
            OnTimeChanged?.Invoke(currentTime);
            Debug.Log("Night");
        }

        timeText.text = currentTimeOfDay.ToString("F2");
        sunLight.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 15f) - 90, 170, 0);
        uiImage.color = Color.Lerp(Color.black, Color.white, currentTimeOfDay / 24f);
    }

    private void UpdateLight(){
        float sunRotation = (currentTimeOfDay / 24f) * 360f;
        sunLight.transform.localRotation = Quaternion.Euler(sunRotation - 90f, sunposition, 0);

        float moonRotation = ((currentTimeOfDay + 12f) / 24f) * 360f;
        moonLight.transform.localRotation = Quaternion.Euler(moonRotation - 90f, moonposition, 0);
    }
}