using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public static Score _instance;
    public int score = 0;
    public string currentLevel = "1";
    public int missed;

    public IDictionary LevelSpeed = new Dictionary<string, int>()
    {
        {"1", 2},
        {"2", 2},
        {"3", 1},
        {"4", 1},
        {"5", 1},
        {"6", 1},
        {"7", 1},
        {"8", 1},
        {"9", 1},
        {"10", 1},
    };

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
        missed = 0;
    }

    private void Update()
    {
        try
        {
            if (_instance.score < 10)
            {
                AudioManager.instance.PitchUP("Theme", 0.8f);
                currentLevel = "1";
            }

            if (_instance.score >= 50 && _instance.score < 130)
            {
                AudioManager.instance.PitchUP("Theme", 0.9f);
                currentLevel = "2";
            }

            if (_instance.score >= 130 && _instance.score < 230)
            {
                AudioManager.instance.PitchUP("Theme", 1f);
                currentLevel = "3";
            }

            if (_instance.score >= 230 && _instance.score < 350)
            {
                AudioManager.instance.PitchUP("Theme", 1.2f);
                currentLevel = "3";
            }

            if (_instance.score >= 350 && _instance.score < 450)
            {
                AudioManager.instance.PitchUP("Theme", 1.4f);
                currentLevel = "4";
            }

            if (_instance.score >= 450 && _instance.score < 550)
            {
                AudioManager.instance.PitchUP("Theme", 1.5f);
                currentLevel = "5";
            }

            if (_instance.score >= 550 && _instance.score < 900)
            {
                AudioManager.instance.PitchUP("Theme", 1.6f);
                currentLevel = "6";
            }

            if (_instance.score >= 900 && _instance.score < 1000)
            {
                AudioManager.instance.PitchUP("Theme", 1.4f);
                currentLevel = "7";
            }

            if (_instance.score >= 1000 && _instance.score < 1150)
            {
                AudioManager.instance.PitchUP("Theme", 1.5f);
                currentLevel = "8";
            }
        }
        catch { }

    }

}
