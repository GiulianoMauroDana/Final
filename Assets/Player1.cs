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
    [SerializeField] private Image barHealth;
    [SerializeField] private int _health;
    private static int _score;
    //private static int _damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        WinCondision();
        Reiniciar();
        UpdateUI();
    }
    private void OnEnable()
    {
        Enemy.enemyKill += CountPoints;
        Enemy.enemyDamage += CountDamage;
        boxHealth.healthRestore += CountHealth;

    }
    private void OnDisable()
    {
        Enemy.enemyKill -= CountPoints;
        Enemy.enemyDamage -= CountDamage;
        boxHealth.healthRestore -= CountHealth;

    }  
    
    private void CountHealth(int health)
    {
        if (_health<100)
        {
            _health += health;
        }
    }

    private void CountDamage(int damage)
    {
        ApllyDamage(damage);
    }

    private void ApllyDamage(int damage)
    {
        _health -= damage;
        UpdateUI();
        if (_health <= 0)
        {
            Destroy(gameObject);
            titleText.text = "Lose ";
            subtitleText.text = "Press R to Restart";
        }
    }

    private void CountPoints(int scoreEnter)
    {
        _score+=scoreEnter;
        UpdateUI();
    }
    private void UpdateUI()
    {
        scoreText.text = "Score:" + _score.ToString();
        barHealth.fillAmount = _health / 100f;
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
