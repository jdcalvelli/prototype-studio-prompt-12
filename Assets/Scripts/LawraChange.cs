using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawraChange : MonoBehaviour
{
    private enum lawraStates
    {
        CLEAR,
        PEEKING,
        LOOKING,
    }

    private lawraStates _currentState;

    [SerializeField] private Sprite lawraPeeking;
    [SerializeField] private Sprite lawraLooking;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
