using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Camera")] 
    [SerializeField] private Camera mainCam;

    [Header("Views")]
    [SerializeField] private GameObject mainView;
    [SerializeField] private GameObject gameOverView;
    [SerializeField] private TextMeshProUGUI scoreView;

    [Header("Controllers")]
    [SerializeField] private ScreenChange screenChangeController;
    [SerializeField] private LawraChange lawraChangeController;

    public float score;

    [SerializeField] private bool _isScoring = true;
    
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
        if (Input.GetKeyDown("space"))
        {
            screenChangeController.ChangeScreen();
        }
        
        if (Input.GetKeyDown("r"))
        {
            Debug.Log("restart");
            // need a more robust restart function
            score = 0;
            _isScoring = true;
            screenChangeController.ChangeScreen();
            StartCoroutine(lawraChangeController.LawraBehavior());
            mainView.SetActive(true);
            gameOverView.SetActive(false);
        }
        
        // check state
        if (screenChangeController.currentState == ScreenChange.ComputerStates.GODOT)
        {
            if (lawraChangeController.currentState == LawraChange.lawraStates.LOOKING)
            {
                Debug.Log("game over");
                _isScoring = false;
                Sequence camShake = DOTween.Sequence();
                camShake.Append(
                    mainCam.DOShakePosition(2, 4, 3)
                );
                camShake.AppendCallback(() =>
                {
                    mainCam.transform.position = new Vector3(0, 0, 0);
                    mainView.SetActive(false);
                    gameOverView.SetActive(true);
                });
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
        scoreView.text = Math.Round(score, 1).ToString();
    }
}
