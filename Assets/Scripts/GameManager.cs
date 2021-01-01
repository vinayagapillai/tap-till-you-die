using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int spawnTime;
    public TextMeshProUGUI scoreText;
    public GameObject SpawnPrefab;
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTimer());
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(Score._instance.score.ToString());
        if(Score._instance.missed == 3)
        {
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);

        }
    }

    public void Paused()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
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
        }
    }
}
