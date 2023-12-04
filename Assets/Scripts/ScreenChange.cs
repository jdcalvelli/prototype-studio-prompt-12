using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChange : MonoBehaviour
{
    private enum computerStates
    {
        UNITY,
        GODOT,
    }

    private computerStates _currentState;
    
    [SerializeField] private Sprite unityScreen;
    [SerializeField] private Sprite godotScreen;
    // Start is called before the first frame update
    void Start()
    {
        // start it at the unity image defaulted
        _currentState = computerStates.UNITY;
        GetComponent<SpriteRenderer>().sprite = unityScreen;
        
    }

    // Update is called once per frame
    void Update()
    {
        // check inputs
        if (Input.GetKeyDown("space"))
        {
            switch (_currentState)
            {
                case computerStates.UNITY:
                    _currentState = computerStates.GODOT;
                    GetComponent<SpriteRenderer>().sprite = godotScreen;
                    break;
                case computerStates.GODOT:
                    _currentState = computerStates.UNITY;
                    GetComponent<SpriteRenderer>().sprite = unityScreen;
                    break;
            }
        }
    }
}
