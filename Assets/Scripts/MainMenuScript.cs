using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject soundFull;
    public GameObject soundOff;
    public GameObject howToMenuVar;
    public TextMeshProUGUI insultBar;
    string[] insults = { "When next update?, maybe for valimai update",
                         "strategically its impossible to reach the score 69,420", 
                         "*add insult here*",
                         "you are a literal psycopath if you play this game a second time",
                         "gamers dont die",
                         "bit.ly/3v9Mmhb",
                         "top score: 69,420"};


    private void Start()
    {
        ChangeInsult();
    }

    private void Update()
    {
        AudioManager.instance.PitchUP("Theme", 1f);
    }

    public void ChangeInsult()
    {
        insultBar.SetText(insults[Random.Range(0, insults.Length)]);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }

    public void Mute()
    {
        ChangeInsult();
        if (soundFull.activeSelf)
        {
            AudioManager.instance.Stop("Theme");
            soundFull.SetActive(false);
            soundOff.SetActive(true);
        }
        else
        {
            AudioManager.instance.Play("Theme", 0.1f);
            soundFull.SetActive(true);
            soundOff.SetActive(false);
        }
    }

    public void howToMenu()
    {
        ChangeInsult();
        if (howToMenuVar.activeSelf)
        {
            howToMenuVar.SetActive(false);
        }
        else
        {
            howToMenuVar.SetActive(true);
        }
    }

}
