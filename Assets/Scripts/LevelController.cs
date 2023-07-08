using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Changeable variables
    private int generator;
    private GameObject newGem;
    private List<GameObject> gemSpots,statues;
    private StatueController statueController;
    private GemBehaviour gemBehaviour;
    //private statueController statueController;

    // Final Variables
    public static LevelController Instance { get; private set; }
    private GemCompendium compendium;

    public GameObject gem;
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
        compendium = GemCompendium.Instance;
        gemSpots = new List<GameObject>();
        statues = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void loadMap()
    {
        gemSpots.Clear();
        statues.Clear();
        statues.AddRange(GameObject.FindGameObjectsWithTag("statue"));        
        gemSpots.AddRange(GameObject.FindGameObjectsWithTag("gemSpot"));
        generateGems();
    }
    void generateGems()
    {
        generator = Random.Range(0, gemSpots.Count);
        foreach(GemCompendium.GemData gemType in compendium.gemGlossary)
        {
            gemBehaviour = newGem.GetComponent<GemBehaviour>();
            gemBehaviour.data = gemType;
            Instantiate(newGem, gemSpots[generator].transform.position, Quaternion.identity);
            gemSpots.Remove(gemSpots[generator]);
        }
    }
    void loadGem(GameObject gem, GameObject statue) {
        gemBehaviour = gem.GetComponent<GemBehaviour>();
        statueController = statue.GetComponent<StatueController>();
        if (gemBehaviour.data.id == statueController.id)
        {
            //statueController.openPuzzle();
        }
        else
        {
            
        }
    }
}
