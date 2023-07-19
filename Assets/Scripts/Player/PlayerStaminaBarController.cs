using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStaminaBarController : MonoBehaviour
{
    PlayerDashScript playerDashScript;

    public GameObject player;

    [SerializeField] Image cooldownBar; // Reference to the UI bar image
    [SerializeField] float fillSpeed = 2f; // Speed at which the UI bar fills
    
    public void Start()
    {
        playerDashScript = player.GetComponent<PlayerDashScript>();
    }
    public void UpdateCooldownUI()
    {

        float cooldownProgress = 1f - (playerDashScript.currentCooldown / playerDashScript.maxCooldown);

        Debug.Log(playerDashScript.currentCooldown);
        Debug.Log(playerDashScript.maxCooldown);

        float targetFillAmount = cooldownProgress;

        // Smoothly interpolate the fill amount using Lerp
        cooldownBar.fillAmount = Mathf.Lerp(cooldownBar.fillAmount, targetFillAmount, Time.deltaTime * fillSpeed);

    }


    void Update()
    {
        UpdateCooldownUI();
    }
}
