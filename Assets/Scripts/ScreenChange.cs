using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScreenChange : MonoBehaviour
{
    public enum ComputerStates
    {
        UNITY,
        GODOT,
    }

    public ComputerStates currentState;
    
    [SerializeField] private Sprite unityScreen;
    [SerializeField] private Sprite godotScreen;
    
    /// <summary>
    /// call function to change the state of the screen and its view
    /// </summary>
    public void ChangeScreen()
    {
        switch (currentState)
        {
            case ComputerStates.UNITY:
                currentState = ComputerStates.GODOT;
                GetComponent<SpriteRenderer>().sprite = godotScreen;
                break;
            case ComputerStates.GODOT:
                currentState = ComputerStates.UNITY;
                GetComponent<SpriteRenderer>().sprite = unityScreen;
                break;
        }
    }
}
