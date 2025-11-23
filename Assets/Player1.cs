using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI subtitleText;
    [SerializeField] private int health;
    [SerializeField] private Image barHealth;
    private static int _score;
    private static int _damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        WinCondision();
        Reiniciar();
        ApplyDamage();
    }
    private void OnEnable()
    {
        Enemy.enemyKill += CountPoints;
        Enemy.enemyDamage += CountDamage;
    }
    private void OnDisable()
    {
        Enemy.enemyKill -= CountPoints;
        Enemy.enemyDamage -= CountDamage;
    }  
    
    private void CountDamage(int damage)
    {
        _damage += damage;
        UpdateUI();
    }

    private void CountPoints(int scoreEnter)
    {
        _score+=scoreEnter;
        UpdateUI();
    }
    private void UpdateUI()
    {
        scoreText.text = "Score:" + _score.ToString();
        barHealth.fillAmount = health / 100f;
    }

    private void ApplyDamage()
    {
        health-= _damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            UpdateUI();
        }
    }

    private void WinCondision()
    {
        if (_score == 4)
        {
            titleText.text = "win";
            subtitleText.text = "Press R to restart";
            Time.timeScale = 0f;
            _score = 0;
        }
    }
    private void Reiniciar()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Playground 1");
            Time.timeScale = 1f;
        }
    }
}
