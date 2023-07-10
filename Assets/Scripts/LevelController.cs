using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    // Changeable variables

    // PRIVATE
    private List<GameObject> statues;
    private List<int> correctPositions;
    private int generator;
    private GameObject lockedDoor;

    // PUBLIC  

    // Final Variables    

    // PRIVATE

    // PUBLIC
    public static LevelController Instance { get; private set; }

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
        statues = new List<GameObject>();
        correctPositions = new List<int>();
        loadMap();
    }

    public void loadMap()
    {
        //gemSpots.Clear();
        correctPositions.Clear();
        statues.Clear();
        statues.AddRange(GameObject.FindGameObjectsWithTag("statue"));
        lockedDoor = GameObject.FindGameObjectWithTag("lockedDoor");
        correctPositions = new List<int> {1,1,1};
        /*
        // Adding the correct sequence in the level
        foreach (GameObject item in statues)
        {
            generator = Random.Range(1, 3);
            correctPositions.Add(generator);
        }*/
        //gemSpots.AddRange(GameObject.FindGameObjectsWithTag("gemSpot"));
        //generateGems();        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)) { checkStatues(); }
    }
    public bool checkStatues()
    {
        int i = 0;
        bool sequenceCorrect = true;
        foreach(GameObject statue in statues) {            
            if(statue.GetComponent<StatueController>().position != correctPositions[i++])
            {
                sequenceCorrect = false;                
            }
        }
        if (sequenceCorrect)
        {
            Destroy(lockedDoor);
        }
        return sequenceCorrect;
    }
}
