using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Views")]
    [SerializeField] private GameObject mainView;
    [SerializeField] private GameObject gameOverView;
    [SerializeField] private TextMeshProUGUI scoreView;

    [Header("Controllers")]
    [SerializeField] private ScreenChange screenChangeController;
    [SerializeField] private LawraChange lawraChangeController;

    public float score;

    private bool _isScoring = true;
    
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
            mainView.SetActive(true);
            gameOverView.SetActive(false);
            score = 0;
            _isScoring = true;
            //
        }
        
        // check state
        if (screenChangeController.currentState == ScreenChange.ComputerStates.GODOT)
        {
            if (lawraChangeController.currentState == LawraChange.lawraStates.LOOKING)
            {
                Debug.Log("game over");
                mainView.SetActive(false);
                gameOverView.SetActive(true);
                _isScoring = false;
            }
            else
            {
                if (_isScoring)
                {
                    score += Time.deltaTime;
                }
            }
        }
        
        // set view score to be score value
        scoreView.text = Math.Round(score, 2).ToString();
    }
}
