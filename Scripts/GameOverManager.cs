using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverObject;

    public static bool isGameOver;

    private void Awake() 
    {
        gameOverObject.SetActive(false);
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(isGameOver == true)
        {
            gameOverObject.SetActive(true);
        }
    }
}
