using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayNightManager : MonoBehaviour {
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private Image uiImage;
    public event Action<NPCData.TimeOfDay> OnTimeChanged;
    private NPCData.TimeOfDay currentTime;
    
    
    [SerializeField] private Light sun;
    [SerializeField] private float secondsInFullDay = 300f;
    [SerializeField] private float gracePeriod = 0.02f;
    [Range(0, 1)] [SerializeField] private float currentTimeOfDay = 0f;
    private float timeMultiplier = 1f;
    private float sunInitialIntensity;
    public bool isPaused;

    private void Start() {
        sunInitialIntensity = sun.intensity;
    }
    
    public void PauseTime() {
        isPaused = true;
    }
    
    public void ResumeTime() {
        isPaused = false;
    }
    
    private void Update() {
        if (isPaused) {
            return;
        }
        UpdateSun();
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
        if (currentTimeOfDay >= 1) {
            currentTimeOfDay = 0;
        }
        
        if (currentTimeOfDay >= 0.0f && currentTimeOfDay <= 0.2f && currentTime != NPCData.TimeOfDay.Morning) {
            timeText.text = "Morning";
            currentTime = NPCData.TimeOfDay.Morning;
            uiImage.color = new Color(1, 1, 0, 1);
            OnTimeChanged?.Invoke(NPCData.TimeOfDay.Morning);
        }
        else if (currentTimeOfDay >= 0.2f && currentTimeOfDay <= 0.4f && currentTime != NPCData.TimeOfDay.Noon) {
            timeText.text = "Noon";
            currentTime = NPCData.TimeOfDay.Noon;
            uiImage.color = new Color(1, 0.92f, 0.016f, 1);
            OnTimeChanged?.Invoke(NPCData.TimeOfDay.Noon);
        }
        else if (currentTimeOfDay >= 0.4f && currentTimeOfDay <= 0.6f && currentTime != NPCData.TimeOfDay.Afternoon) {
            timeText.text = "Afternoon";
            currentTime = NPCData.TimeOfDay.Afternoon;
            uiImage.color = new Color(1, 0.5f, 0, 1);
            OnTimeChanged?.Invoke(NPCData.TimeOfDay.Afternoon);
        }
        else if (currentTimeOfDay >= 0.6f && currentTimeOfDay <= 0.8f && currentTime != NPCData.TimeOfDay.Evening) {
            timeText.text = "Evening";
            currentTime = NPCData.TimeOfDay.Evening;
            uiImage.color = new Color(1, 0.5f, 0, 1);
            OnTimeChanged?.Invoke(NPCData.TimeOfDay.Evening);
        }
        else if (currentTimeOfDay >= 0.8f && currentTimeOfDay <= 1.0f && currentTime != NPCData.TimeOfDay.Night) {
            timeText.text = "Night";
            currentTime = NPCData.TimeOfDay.Night;
            uiImage.color = new Color(0, 0, 1, 1);
            OnTimeChanged?.Invoke(NPCData.TimeOfDay.Night);
        }
    }

    private void UpdateSun() {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f), 0, 0);
        //TODO: Refactor this to use ROTATION instead of CurrentTimeOfDay
        if (currentTimeOfDay >= 0.2f + gracePeriod && currentTimeOfDay <= 0.4f) {
            sun.intensity = sunInitialIntensity;
        }
        else if (currentTimeOfDay >= 0.0f && currentTimeOfDay <= 0.2f + gracePeriod) {
            float smoothStep = (currentTimeOfDay - gracePeriod) * (currentTimeOfDay - gracePeriod) * (3 - 2 * (currentTimeOfDay - gracePeriod));
            sun.intensity = Mathf.Lerp(0, sunInitialIntensity, smoothStep);
        }
        else if (currentTimeOfDay >= 0.4f && currentTimeOfDay <= 0.6f) {
            sun.intensity = Mathf.Lerp(sunInitialIntensity, 0, (currentTimeOfDay - 0.4f) * 5);
        }
        else if (currentTimeOfDay >= 0.6f && currentTimeOfDay <= 0.8f) {
            sun.intensity = 0;
        }
        else if (currentTimeOfDay >= 0.8f + gracePeriod && currentTimeOfDay <= 1.0f) {
            float smoothStep = (currentTimeOfDay - 0.8f - gracePeriod) * (currentTimeOfDay - 0.8f - gracePeriod) * (3 - 2 * (currentTimeOfDay - 0.8f - gracePeriod));
            sun.intensity = Mathf.Lerp(0, sunInitialIntensity, smoothStep);
        }
    }

    public void SetTime(float time) {
        currentTimeOfDay = time;
    }

    public void SetTimeMultiplier(float multiplier) {
        timeMultiplier = multiplier;
    }

    public float GetTime() {
        return currentTimeOfDay;
    }

    public float GetTimeMultiplier() {
        return timeMultiplier;
    }

    public float GetSunIntensity() {
        return sun.intensity;
    }

    public float GetSunInitialIntensity() {
        return sunInitialIntensity;
    }

    public float GetSecondsInFullDay() {
        return secondsInFullDay;
    }

    public void SetSunIntensity(float intensity) {
        sun.intensity = intensity;
    }

    public void SetSunInitialIntensity(float intensity) {
        sunInitialIntensity = intensity;
    }

    public void SetSecondsInFullDay(float seconds) {
        secondsInFullDay = seconds;
    }

    public void SetSunRotation(Quaternion rotation) {
        sun.transform.localRotation = rotation;
    }

    public Quaternion GetSunRotation() {
        return sun.transform.localRotation;
    }

    public void SetSun(Light newSun) {
        sun = newSun;
    }

    public Light GetSun() {
        return sun;
    }

    public void SetCurrentTimeOfDay(float time) {
        currentTimeOfDay = time;
    }

    public float GetCurrentTimeOfDay() {
        return currentTimeOfDay;
    }
}
