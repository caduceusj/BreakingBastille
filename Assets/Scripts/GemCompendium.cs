using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCompendium : MonoBehaviour
{
    public static GemCompendium Instance { get; private set; }
    public List<GemCompendium.GemData> gemGlossary;
    public List<Sprite> sprites;

    public struct GemData
    {
        public int id;
        public string color;
        public string description;
        public GemData(string color, int id, string description)
        {
            this.id = id;
            this.color = color;
            this.description = description;
        }

    }

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

    // Start is called before the first frame update
    void Start()
    {
        GemData gemRed = new("Vermelho", 0, "um rubi vermelho como uma gota de sangue");
        GemData gemGreen = new("Verde", 0, "uma Esmeralda verde meio transparente");
        GemData gemBlue = new("Azul", 0, "um Diamante azul opaco");
        gemGlossary = new List<GemData> { gemRed, gemGreen,gemBlue };             
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
