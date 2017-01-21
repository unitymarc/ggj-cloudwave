using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonsController : MonoBehaviour {

        public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);

    }

        public void ExitGameBtn()
        {
        Application.Quit();
        }
}
