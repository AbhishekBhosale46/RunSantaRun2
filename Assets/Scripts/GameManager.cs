using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isStarted;
    public GameObject platSpwaner;

    [Header("Game Over")]
    public GameObject gameOverPanel;

    [Header("Game Start")]
    public GameObject gameStartPanel;

    [Header("Score")]
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text bestText;
    public TMPro.TMP_Text giftText;

    [Header("GO Score")]
    public TMPro.TMP_Text goBestText;
    public TMPro.TMP_Text goGiftText;

    public int score = 0;
    int best, gifts;
    bool countScore;

    void Start()
    {

        if(instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1;
        best = PlayerPrefs.GetInt("bestScore");
        bestText.text = best.ToString();

        gameStartPanel.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (!isStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameStartPanel.SetActive(false);
                GameStart();
            }
        }
        platSpwaner.SetActive(true);

        // Exit the application
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void GameStart()
    {
        Time.timeScale = 1;
        isStarted = true;
        countScore = true;
        StartCoroutine(UpdateScore());
        platSpwaner.SetActive(true);
    }

    public void GameOver()
    {
        countScore = false;
        gameOverPanel.SetActive(true);
        platSpwaner.SetActive(false);
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("bestScore", best);
        }
        goBestText.text = best.ToString();
        goGiftText.text = gifts.ToString();

    }

    IEnumerator UpdateScore()
    {
        while (countScore)
        {
            yield return new WaitForSeconds(0.45f);
            score++;
            if (score > best)
            {
                scoreText.text = score.ToString();
                bestText.text = score.ToString();
            }
            else
            {
                scoreText.text = score.ToString();
            }
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("SantaScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GetGift()
    {
        gifts++;
        giftText.text = gifts.ToString();
    }

}
