using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerController : MonoBehaviour
{
    public bool nextScene;
    public int indexScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(indexScene);
    }

   
}
