using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class StatueController : MonoBehaviour
{
    [SerializeField] private bool inArea;
    private Animator animPlayer;

    public GameObject text = null;


    [field: SerializeField] public int virtualPosition { get; private set; } = 0;
    [field: SerializeField] public int realPosition { get; private set; } = 0;

    private void Start()
    {
        animPlayer = GetComponent<Animator>();
        SetStatuePosition();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inArea && Input.GetKeyDown(KeyCode.F))
        {
            virtualPosition++;
            SetStatuePosition();
        }
    }

    private void SetStatuePosition()
    {
        realPosition = Math.Abs((((virtualPosition - 1) % 4) + 4) % 4 - 2) + 1;
        animPlayer.SetInteger("Position", realPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inArea = true;
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

}