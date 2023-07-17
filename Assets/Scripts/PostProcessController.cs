using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessController : MonoBehaviour
{
    private PostProcessVolume postProcess;
    private Vignette vignetteEffect;

    // Start is called before the first frame update
    void Start()
    {
        postProcess = GetComponent<PostProcessVolume>();
        // print(postProcess.profile.components.)

        /*foreach(var component in postProcess.profile.settings)
        {
            print(component.name);
        }*/
        
        // postProcess.gameObject
        Vignette tmp;

        if(postProcess.profile.TryGetSettings<Vignette>(out tmp))
        {
            vignetteEffect = tmp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(vignetteEffect != null)
        {
            print($"mode: {vignetteEffect.mode.value}");
        }
    }
}
