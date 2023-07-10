using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class StatueController : MonoBehaviour
{
    public Animator animPlayer;

    public GameObject text = null;

    public bool inArea = false, animIsPlaying = false;

    [SerializeField]
    private Collider collision;

    [SerializeField]
    public int position { get; private set; } = 2;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("AAAAAAAAAAAA");
        if (other.CompareTag("Player"))
        {
            inArea = true;
            Debug.Log("AAAAAAAAAAAA");
            text.SetActive(true);


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            inArea = false;
            text.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {


        

        if (inArea) { 
        }
        if (inArea && Input.GetKeyDown(KeyCode.F) && animIsPlaying == false)
        {
            Debug.Log("F Entrou");
            animPlayer.SetInteger("Position", position + 1);
            position++;
            if (animPlayer.GetInteger("Position") > 3)
            {
                animPlayer.SetInteger("Position", 1);
                position = 1;
            }
            // Play the specific animation
            if (animPlayer != null)
            {
                if (position == 1)
                {
                    animPlayer.SetInteger("Position", 1);
                }

                if (position == 2)
                {
                    animPlayer.SetInteger("Position", 2);

                }
                if (position == 3)
                {
                    animPlayer.SetInteger("Position", 3);

                }
            }
        }
    }
}