using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    #region Variables

    [Header ("Volume Savers")]
    public static float BGMUpdater = 1f;
    public static float SFXUpdater = 1;
    public static float MasterVolumeUpdater = 1;

    [Header ("Pause Bool")]
    public static bool Pause = false;

    #endregion

    #region Refernces

    [Header("Master")]
    public Slider MasterVolumeSlider;
    [SerializeField] private TextMeshProUGUI MasterVolumeText;

    [Header("BGM")]
    [SerializeField] private TextMeshProUGUI BGMVolumeText;
    public AudioSource BGM;
    public Slider BGMSlider;

    [Header("SFX")]
    [SerializeField] private TextMeshProUGUI SFXVolumeText;
    public AudioSource SFX;
    public Slider SFXSlider;

    [Header("Panels")]
    [SerializeField] private GameObject PauseMenuPanel;
    [SerializeField] private GameObject OptionsPanel;

    #endregion

    #region Start
    private void Start()
    {
        BGMSlider.value = BGMUpdater;
        SFXSlider.value = SFXUpdater;
        MasterVolumeSlider.value = MasterVolumeUpdater;
    }

    #endregion

    #region Buttons
    public void PauseMenuPress()
    {
        Pause = true;
        PauseMenuPanel.SetActive(true);
        BGM.Pause();
    }
    public void resume()
    {
        Pause = false;
        BGM.Play();
        PauseMenuPanel.SetActive(false);
        
    }
    public void Options()
    {
        PauseMenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }
    public void Return()
    {
        OptionsPanel.SetActive(false);
        PauseMenuPanel.SetActive(true);
    }
    public void MainMenu()
    {
        Pause = false;
        SceneManager.LoadScene(0);
    }

    #endregion

    #region Volume Setters
    public void MasterVolumeSet()
    {
        AudioListener.volume = MasterVolumeSlider.value;
        MasterVolumeUpdater = MasterVolumeSlider.value;
        var fixedValue = MasterVolumeSlider.value * 100;
        var realFixedValue = (int)fixedValue;
        MasterVolumeText.text = realFixedValue.ToString();
            
    }
    public void BGMVolumeSet()
    {
       BGM.volume = BGMSlider.value;
        BGMUpdater = BGMSlider.value;
        var fixedValue = BGMSlider.value * 100;
        var realFixedValue = (int)fixedValue;
        BGMVolumeText.text = realFixedValue.ToString();
    }
    public void SFXVolumeSet()
    {
        SFX.volume = SFXSlider.value;
        SFXUpdater = SFXSlider.value;
        var fixedValue = SFXSlider.value * 100;
        var realFixedValue = (int)fixedValue;
        SFXVolumeText.text = realFixedValue.ToString();
    }

    #endregion

    #region Update and OnFocus
    private void Update()
    {
        MasterVolumeSet(); BGMVolumeSet(); SFXVolumeSet();
        if (PauseMenuPanel.activeSelf == true)
        {
            Pause = true;
        }

    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
            Pause = true;
            PauseMenuPanel.SetActive(true);
        }
        if (focus == true)
        {
            Pause = true;
        }

    }

    #endregion

}
