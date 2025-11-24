using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI subtitleText;
    [SerializeField] private int _score;    
    public static Action<int> enemyKill;    
   // private bool 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {        
        Reiniciar();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            titleText.text = "Lose ";
            subtitleText.text = "Press R to Restart";
            Destroy(collision.gameObject);            
        }
        if (collision.gameObject.CompareTag("bullet"))
        {
            enemyKill?.Invoke(_score);
            Destroy(collision.gameObject);
            Destroy(gameObject);
           
        }
    }
    //private void
    private void Reiniciar()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Playground 1");
        }
    }   
}
