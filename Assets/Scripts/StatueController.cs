using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class StatueController : MonoBehaviour
{
    public Animator animPlayer;

    public GameObject text = null;

    public bool inArea = false;

    [SerializeField]
    private Collider collision;

    [SerializeField]
    private int position = 2;

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
    void Start()
    {





    }

    // Update is called once per frame
    void Update()
    {
        if(inArea) { 
        }
        if (inArea && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F Entrou");
            position++;

            if (position > 3)
            {
                position = 1;
            }
            // Play the specific animation
            if (animPlayer != null)
            {
                if (position == 1)
                {
                    animPlayer.Play("3-1");
                }

                if (position == 2)
                {
                    animPlayer.Play("1-2");
                }
                if (position == 3)
                {
                    animPlayer.Play("2-3");
                }
            }
        }
    }
}