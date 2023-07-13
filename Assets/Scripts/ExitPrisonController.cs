using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPrisonController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("FUGIU!!");
        }
    }
}
