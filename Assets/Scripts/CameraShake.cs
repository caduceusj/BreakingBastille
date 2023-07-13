using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; set; }

    private CinemachineVirtualCamera ccv;
    private float shakeTimer;
    private float shakeTimerTotal;
    private float startingIntensity;

    private void Awake()
    {
        Instance = this;
        ccv = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cmp = ccv.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cmp.m_FrequencyGain = intensity;

        startingIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;
    }

    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;

            CinemachineBasicMultiChannelPerlin cmp = ccv.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cmp.m_FrequencyGain = Mathf.Lerp(startingIntensity, .3f, (1 - (shakeTimer / shakeTimerTotal)));

        }
    }
}
