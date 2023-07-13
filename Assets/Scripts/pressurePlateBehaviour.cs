using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlateBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 originalPos;
    private LevelController levelController;
    private bool trigger,block,moveBack;
    [SerializeField]private List<GameObject> trapsAssociated;
    
    void Start()
    {
        levelController = LevelController.Instance;
        block = false;
        originalPos = transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
    
        if (other.gameObject.CompareTag("Player") && block == false) {
            transform.parent = transform;
            trigger = true;
        }
    }
    /*private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && block == false)
        {
            transform.position -= new Vector3(0, 0.01f, 0);
            moveBack = false;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && block == false)
        {
            moveBack = true;
            other.transform.parent = null;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        /*if (moveBack)
        {
            if(transform.position.y < originalPos.y)
            {
                transform.position += new Vector3(0, 0.01f, 0);
            }
            else
            {
                moveBack = false;
            }
        }*/
        if(trigger)
        {
            if (levelController.checkStatues())
            {
                block = true;               
            }
            else
            {
                foreach (GameObject trap in trapsAssociated) {
                    trap.transform.GetChild(0).GetComponent<TrapBehaviour>().shoot();                        
                }
            }
            trigger = false;
        }
    }
}
