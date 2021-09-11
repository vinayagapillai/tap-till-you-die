using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMan : MonoBehaviour
{
    public static GameMan instance;

    int spawnTime;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI missesText;
    public GameObject SpawnPrefab;
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    public GameObject BG;
    bool changeBGBool = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    void Start()
    {
        ChangeBGColor();
        RestartGame();
        StartCoroutine(SpawnTimer());
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score: " + Score._instance.score.ToString());
        missesText.SetText("Misses Remaining: " + (5 - Score._instance.missed).ToString());
        if(Score._instance.missed == 5)
        {
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
        }

        ColorGuess();
    }

    public void ColorGuess()
    {
        if ((Score._instance.score % 50) == 0 && Score._instance.score != 0 && !changeBGBool)
        {
            ChangeBGColor();
            changeBGBool = true;
            StartCoroutine(BGBool());
        }

        if(Score._instance.score == 130 || Score._instance.score == 230 || Score._instance.score == 350 || Score._instance.score == 450 ||
            Score._instance.score == 550 || Score._instance.score == 900 || Score._instance.score == 1000)
        {
            ChangeBGColor();
        }

    }

    public void ChangeBGColor()
    {
        float r = Random.Range(0, 1f);
        float g = Random.Range(0, 1f);
        float b = Random.Range(0, 1f);
        float trans = Random.Range(0.6f, 1f);
        BG.GetComponent<SpriteRenderer>().color = new Color(r, g, b, trans);
    }

    IEnumerator BGBool()
    {
        yield return new WaitForSeconds(1f);
        changeBGBool = false;
    }


    public void Paused()
    {
        ChangeBGColor();
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void RestartGame()
    {
        Score._instance.missed = 0;
        Score._instance.currentLevel = "1";
        Score._instance.score = 0;
        GameOverMenu.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator SpawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, (int)Score._instance.LevelSpeed[Score._instance.currentLevel]));
            float spawnY = Random.Range
                                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Vector2 pos = new Vector2(spawnX, spawnY);
            Instantiate(SpawnPrefab, pos, Quaternion.identity);

            if (int.Parse(Score._instance.currentLevel) > 4)
            {
                StartCoroutine(SpawnTimerTwo());
            }
        }
    }

    IEnumerator SpawnTimerTwo()
    {
        yield return new WaitForSeconds(0.3f);
        float spawnY = Random.Range
                            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        Vector2 pos = new Vector2(spawnX, spawnY);

        Instantiate(SpawnPrefab, pos, Quaternion.identity);

        if (int.Parse(Score._instance.currentLevel) > 6)
        {
            StartCoroutine(SpawnTimerThree());
        }
    }

    IEnumerator SpawnTimerThree()
    {
        yield return new WaitForSeconds(0.2f);
        float spawnY = Random.Range
                            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        Vector2 pos = new Vector2(spawnX, spawnY);
        Instantiate(SpawnPrefab, pos, Quaternion.identity);
    }




}

