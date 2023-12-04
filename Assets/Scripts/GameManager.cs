using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Views")]
    [SerializeField] private GameObject mainView;
    [SerializeField] private GameObject gameOverView;

    [Header("Controllers")]
    [SerializeField] private ScreenChange screenChangeController;
    [SerializeField] private LawraChange lawraChangeController;
    
    // Start is called before the first frame update
    void Start()
    {
        // call once to get to unity to start
        screenChangeController.ChangeScreen();
        
        // call the lawra change controller
        StartCoroutine(lawraChangeController.LawraBehavior());
    }

    // Update is called once per frame
    void Update()
    {
        // input management
        if (Input.GetKeyDown("space") 
            && mainView.activeSelf)
        {
            screenChangeController.ChangeScreen();
        }
        else if (Input.GetKeyDown("r")
                 && gameOverView.activeSelf)
        {
            Debug.Log("restart");
            // need a more robust restart function
            screenChangeController.ChangeScreen();
            StartCoroutine(lawraChangeController.LawraBehavior());
            //
            mainView.SetActive(true);
            gameOverView.SetActive(false);
        }
        
        // check state
        if (screenChangeController.currentState == ScreenChange.ComputerStates.GODOT 
            && lawraChangeController.currentState == LawraChange.lawraStates.LOOKING)
        {
            Debug.Log("game over");
            mainView.SetActive(false);
            gameOverView.SetActive(true);
        }
    }
}
