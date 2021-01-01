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
        {"1", 4},
        {"2", 3},
        {"3", 2}
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
        if (_instance.score >= 50 && _instance.score < 55)
            currentLevel = "2";
        if (_instance.score >= 60)
            currentLevel = "3";
    }

}
