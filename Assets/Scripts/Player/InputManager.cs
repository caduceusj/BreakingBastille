using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputStarterAssets playerInput;
    private InputStarterAssets.PlayerActions player;
    
    // Start is called before the first frame update
    void Start()
    {
        playerInput = new InputStarterAssets();
        player = playerInput.Player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        player.Enable();
    }

    private void OnDisable()
    {
        player.Disable();
    }
}
