using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI subtitleText;
    private static int _score;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        WinCondision();
        Reiniciar();
    }
    private void OnEnable()
    {
        Enemy.enemyKill += CountPoints;
        
    }
    private void OnDisable()
    {
        Enemy.enemyKill -= CountPoints;
        
    }  
    
    private void CountPoints(int scoreEnter)
    {
        _score+=scoreEnter;
        UpdateUI();
    }
    private void UpdateUI()
    {
        scoreText.text = "Score:" + _score.ToString();
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
