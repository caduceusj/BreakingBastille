using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Final Variables
    public static GameController Instance { get; private set; }
    LevelController levelController;

    // Changeable Variables
    private GameObject playerItem;

    // Start is called before the first frame update

    void Awake()
    {

        if (Instance != null && Instance != this)
        {

            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        levelController = LevelController.Instance;
        levelController.loadMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void collectItem(GameObject item)
    {
        if (playerItem != null) Instantiate(playerItem, item.transform);
        playerItem = item;
    }
}
