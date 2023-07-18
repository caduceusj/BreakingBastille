using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlateBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> trapsAssociated;
    [SerializeField] private GameObject door;

    private LevelController levelController;
    
    private bool block;

    void Start()
    {
        levelController = LevelController.Instance;
        block = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && block == false) {

            if (levelController.checkStatues())
            {
                block = true;
                door.GetComponent<Animator>().SetBool("isOpen", true);
            }
            else
            {
                foreach (GameObject trap in trapsAssociated)
                {
                    trap.GetComponent<TrapBehaviour>().shoot();
                }
            }
        }
    }
}
