using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{
    public int sceneNumber;

    public int gameScene;

    public int achivments;
    public void SceneTransition()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void GameScene()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void Achivments()
    {
        SceneManager.LoadScene(achivments);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
