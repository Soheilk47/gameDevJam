using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMngr : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("mainGame");
    }

    public void ControlsScene()
    {
        SceneManager.LoadScene("ctrlScene");
    }
}