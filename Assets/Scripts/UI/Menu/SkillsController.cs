using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillsController : MonoBehaviour
{
    [SerializeField] private float baseVision = 2.37f;
    [SerializeField] private float baseSpeed = 35;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D playerLight;

    private void Start() {
        Debug.Log(PlayerPrefs.GetInt("visionLevel"));
        playerLight.pointLightOuterRadius = baseVision + ((float)Convert.ToDouble(PlayerPrefs.GetInt("visionLevel"))) / 5;
        playerLight.pointLightInnerRadius = playerLight.pointLightOuterRadius - 0.15f;
        GetComponent<PlayerMovement>().speed = baseSpeed + (PlayerPrefs.GetInt("speedLevel")) * 5;
    }
}
