using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour
{
    public GameObject QuitWindow;

    public void QuitGame()
        {
            Application.Quit();
            Debug.Log("Game ended.");
        }

    public void QuitWindowOpen()
        {
            QuitWindow.SetActive(true);
        }
    public void QuitWindowExit()
    {
        QuitWindow.SetActive(false);
    }
}
