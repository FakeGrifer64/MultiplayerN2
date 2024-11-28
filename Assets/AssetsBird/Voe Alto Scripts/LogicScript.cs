using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI scoreText;
    [SerializeField] private GameObject lossPanel;
    [SerializeField] private TextMeshProUGUI timeText; 
    private static float timeSurvived;
    public int numOfPlayers;
    public GameObject esperandoPlayer2;
    public GameObject esperandoPlayer2Text;

    public EnemySpawner enemySpawner1;
    public EnemySpawner enemySpawner2;

    private void Awake()
    {
        lossPanel.SetActive(false);
        timeSurvived = 0f;

        enemySpawner1 = GameObject.FindGameObjectWithTag("enemySpawn1").GetComponent<EnemySpawner>();
        enemySpawner2 = GameObject.FindGameObjectWithTag("enemySpawn2").GetComponent<EnemySpawner>();
    }

    private void Update()
    {
        if (numOfPlayers == 2)
        {
            esperandoPlayer2.SetActive(false);
            esperandoPlayer2Text.SetActive(false);
            enemySpawner1.enabled = true;
            enemySpawner2.enabled = true;

            if (lossPanel.activeSelf == false)
            {
                timeSurvived += Time.deltaTime;

                timeText.text = Mathf.Round(timeSurvived).ToString();
            }
        }
    }

    public void gameOver()
    {
        Debug.Log("Função gameOver");
        lossPanel.SetActive(true);
        finalScoreText.text = "Pontuação: " + Mathf.Round(timeSurvived).ToString();
        timeText.text = "Tempo: " + Mathf.Round(timeSurvived) + "s";
    }

    public void RestartGame()
    {
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
