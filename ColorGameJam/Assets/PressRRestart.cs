using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressRRestart : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) NewGame();
    }

    private void NewGame()
    {
        SceneManager.LoadScene(0);
    }


}
