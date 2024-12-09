using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    public static int score;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;
    public static Ui gm;
    public GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        gm = this;

        score = GameObject.FindGameObjectsWithTag("Asteroids").Length;
        score = 0;
        highScore = 0;
        UpdateScore();
        HighScoreData data = SaveLoad.LoadHighScore();
        if(data != null )
        {
            highScore = data.highScore;
        }
    }
    private void OnDestroy()
    {
        if(score > highScore)
        {
            highScore = score;
        }
        HighScoreData data = new HighScoreData(highScore);
        SaveLoad.SaveHighScore(data);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "HighScore: " + highScore;
    }
}
