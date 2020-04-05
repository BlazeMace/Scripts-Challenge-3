using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;

    private bool gameOver;
    private bool restart;
    private int points;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        points = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves ());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds (waveWait);


            if (gameOver)
            {
                restartText.text = "Press 'Z' for Restart";
                restart = true;
                break;
            }
        } 
    }
    public void AddScore(int newScoreValue)
    {
        points += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + points;
        if (points >= 100)
        {
            winText.text = "You win! Game Created By Julian Maceira";
            gameOver = true;
            restart = true;
        }
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over! Game Created By Julian Maceira";
        gameOver = true;
    }
    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
