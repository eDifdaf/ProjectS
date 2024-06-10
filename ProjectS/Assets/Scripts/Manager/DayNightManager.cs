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

    [Header("Light Settings")] 
    public Light sunLight;
    public Light moonLight;

    [SerializeField] private TMP_Text timeText;
    public event Action<TimeOfDay> OnTimeChanged;
    public TimeOfDay currentTime;
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
        if (currentTimeOfDay >= 6.0f && currentTimeOfDay < 11.0f && currentTime != TimeOfDay.Morning){
            currentTime = TimeOfDay.Morning;
            OnTimeChanged?.Invoke(currentTime);
        }
        else if (currentTimeOfDay >= 11.0f && currentTimeOfDay < 14.0f && currentTime != TimeOfDay.Noon){
            currentTime = TimeOfDay.Noon;
            OnTimeChanged?.Invoke(currentTime);
        }
        else if (currentTimeOfDay >= 14.0f && currentTimeOfDay < 18.0f && currentTime != TimeOfDay.Afternoon){
            currentTime = TimeOfDay.Afternoon;
            OnTimeChanged?.Invoke(currentTime);
        }
        else if (currentTimeOfDay >= 18.0f && currentTimeOfDay < 24.0f && currentTime != TimeOfDay.Evening){
            currentTime = TimeOfDay.Evening;
            OnTimeChanged?.Invoke(currentTime);
        }
        else if (currentTimeOfDay >= 0f && currentTimeOfDay < 6.0f && currentTime != TimeOfDay.Night){
            currentTime = TimeOfDay.Night;
            OnTimeChanged?.Invoke(currentTime);
        }
    
        timeText.text = currentTime.ToString();
        sunLight.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 15f) - 90, 170, 0);
    }

    private void UpdateLight()
    {
        if (currentTimeOfDay >= 6.0f && currentTimeOfDay < 11.0f) // Morning
        {
            sunLight.enabled = true;
            moonLight.enabled = false;
            sunLight.transform.rotation = Quaternion.Euler(25f, 0f, 0f); // Adjust these values
        }
        else if (currentTimeOfDay >= 11.0f && currentTimeOfDay < 13.0f) // Noon
        {
            sunLight.enabled = true;
            moonLight.enabled = false;
            sunLight.transform.rotation = Quaternion.Euler(90f, 0f, 0f); // Adjust these values
        }
        else if (currentTimeOfDay >= 13.0f && currentTimeOfDay < 18.0f) // Afternoon
        {
            sunLight.enabled = true;
            moonLight.enabled = false;
            sunLight.transform.rotation = Quaternion.Euler(110f, 0f, 0f); // Adjust these values
        }
        else if (currentTimeOfDay >= 18.0f && currentTimeOfDay < 24.0f) // Evening
        {
            sunLight.enabled = false;
            moonLight.enabled = true;
            sunLight.transform.rotation = Quaternion.Euler(170f,0f, 0f); // Adjust these values
        }
        else
        {
            sunLight.enabled = false;
            moonLight.enabled = true;
            sunLight.transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Adjust these values
            moonLight.transform.rotation = Quaternion.Euler(90f, 0f, 0f); // Adjust these values
        }
    }
}