using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    // Changeable variables

    // PRIVATE
    private List<GameObject> statues,patternsSpawners;
    private List<int> correctPositions;
    private int generator,generator2;
    private GameObject lockedDoor, statuePatternSpawner, newStatuePattern;

    // PUBLIC  


    // Final Variables    

    // PRIVATE    
    [SerializeField] private GameObject statuePattern;
    [SerializeField] private Material black;

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
        patternsSpawners = new List<GameObject> ();
        correctPositions = new List<int>();
        loadMap();
    }

    public void loadMap()
    {
        // Clearing Lists
        //gemSpots.Clear();
        correctPositions.Clear();
        statues.Clear();        
        patternsSpawners.Clear();


        statues.AddRange(GameObject.FindGameObjectsWithTag("statue"));        
        statuePatternSpawner = GameObject.FindGameObjectWithTag("statuePatternSpawner");
        lockedDoor = GameObject.FindGameObjectWithTag("lockedDoor");

        Debug.Log("Pattern Spawners total:");
        for (int i = 0; i < statuePatternSpawner.transform.childCount; i++)
        {
            patternsSpawners.Add(statuePatternSpawner.transform.GetChild(i).gameObject);
            /*Debug.Log(patternsSpawners[i].name);
            Debug.Log(patternsSpawners[i].ToString());
            Debug.Log("");*/
        }

        // Adding the correct sequence in the level
        //int l = 0;
        //Debug.Log("Pattern Spawners selected:");
        foreach (GameObject item in statues)
        {
            // Determining Pattern for Statues
            generator = Random.Range(1, 3);
            correctPositions.Add(generator);

            // Determining which StatuePartternSpawners will have a pattern
            generator2 = Random.Range(0, patternsSpawners.Count);                        
            newStatuePattern = Instantiate(statuePattern, patternsSpawners[generator2].transform.GetChild(0).transform.position, patternsSpawners[generator2].transform.GetChild(0).transform.rotation);            
            newStatuePattern.transform.GetChild(generator - 1).gameObject.GetComponent<MeshRenderer>().material = black;
            patternsSpawners.Remove(patternsSpawners[generator2]);
        }       
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