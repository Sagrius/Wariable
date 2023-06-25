using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public AudioSource BGM;
    public Slider SoundsSlider;
    public TextMeshProUGUI text;
    public void Start()
    {
        AudioListener.volume = 1;
    }
    public void startGame()
    {
        SceneManager.LoadScene(1);
        
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void AudioLevel()
    {
        AudioListener.volume = SoundsSlider.value;
        
    }
    public void volumeUpdate()
    {
        var fixedValue = SoundsSlider.value*100;
        var realfixedValue = (int)fixedValue;
        text.text = realfixedValue.ToString();

    }
    public void Update()
    {
        volumeUpdate();
    }
}
