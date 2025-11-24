using System;
using UnityEngine;

public class boxHealth : MonoBehaviour
{
    [SerializeField] private int health;
    public static Action<int> healthRestore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthRestore?.Invoke(health);
            Destroy(gameObject);
        }        
    }

}
