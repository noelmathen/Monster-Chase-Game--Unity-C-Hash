using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUIController : MonoBehaviour
{
    public void restartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // SceneManager.LoadScene("GamePlay");  //can use this also
    }

    public void homeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
