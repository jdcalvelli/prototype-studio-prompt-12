using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

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
        if (Input.GetKeyDown("space"))
        {
            screenChangeController.ChangeScreen();
        }
    }
}
