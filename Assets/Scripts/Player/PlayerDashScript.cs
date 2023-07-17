using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashScript : MonoBehaviour
{
    
    public float dashTime ;
    public float dashSpeed;
    public FirstPersonController firstPersonController;
    // Start is called before the first frame update
    void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) {
            StartCoroutine(Dash());
        }


    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        while (Time.time < startTime + dashTime)
        {

            firstPersonController._controller.Move((firstPersonController.transform.right * firstPersonController._input.move.x + firstPersonController.transform.forward * firstPersonController._input.move.y ).normalized*  dashSpeed *  Time.deltaTime);
            yield return null;

        }
        }
}
