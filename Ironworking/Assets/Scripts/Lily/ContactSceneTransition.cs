using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContactSceneTransition : MonoBehaviour
{
    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NextScene();
        }

    }

    void NextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneName);
    }


            // Update is called once per frame
            void Update()
    {
        
    }
}
