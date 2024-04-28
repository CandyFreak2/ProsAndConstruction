using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public void LoadSceneByName(string name) 
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(name);
    }

    public void LoadSceneByIndex(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(index);
    }

    public void ExitGame()
    {
        Debug.Log("Game Quitting....");
        Application.Quit();
    }
}

//https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html