using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void playGame()
    {
        int selectedCharacted = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        Debug.Log("The selected character is Player " + (selectedCharacted+1));
        GameManager.instance.PlayerIndex = selectedCharacted;
        SceneManager.LoadScene("GamePlay");
    }
    
}
