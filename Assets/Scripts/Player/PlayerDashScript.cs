using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerDashScript : MonoBehaviour
{
    
    public float dashTime ;
    public float dashSpeed;
    public float currentCooldown = 0f;

    [SerializeField] Image cooldownBar; // Reference to the UI bar image
    [SerializeField] float fillSpeed = 2f; // Speed at which the UI bar fills

    public float maxCooldown = 3f; // Set your desired cooldown time here
    public FirstPersonController firstPersonController;
    public PlayerStaminaBarController playerStaminaBarController;
    // Start is called before the first frame update
    void Start()
    {

        firstPersonController = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;

            // Ensure the cooldown doesn't go below zero
            currentCooldown = Mathf.Max(currentCooldown, 0f);
        }


        playerStaminaBarController.UpdateCooldownUI();

        
        // Update the UI bar to reflect the cooldown progress


        if (Input.GetKeyDown(KeyCode.Q)) {
            StartCoroutine(Dash());
        }


    }

    IEnumerator Dash()
    {

        if (currentCooldown <= 0f)
        {
            float startTime = Time.time;
            while (Time.time < startTime + dashTime)
            {

                firstPersonController._controller.Move((firstPersonController.transform.right * firstPersonController._input.move.x + firstPersonController.transform.forward * firstPersonController._input.move.y).normalized * dashSpeed * Time.deltaTime);
                yield return null;
                currentCooldown = maxCooldown;

            }

        }
    }
}
