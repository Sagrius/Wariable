using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    #region Variables
    [Header ("SerializedFields")]
    [SerializeField] private GameObject PauseMenuPanel;
    [SerializeField] private GameObject OptionsPanel;
    [SerializeField] private TextMeshProUGUI MasterVolumeText;
    [SerializeField] private TextMeshProUGUI BGMVolumeText;
    [SerializeField] private TextMeshProUGUI SFXVolumeText;
    [SerializeField] public AudioSource BGM;
    [SerializeField] public static float BGMUpdater = 1f;
    [SerializeField] public AudioSource SFX;
    [SerializeField] public static float SFXUpdater = 1;
    [SerializeField] public static float MasterVolumeUpdater = 1;
    public static bool Pause = false;
    public Slider MasterVolumeSlider;
    public Slider BGMSlider;
    public Slider SFXSlider;

    #endregion


    private void Start()
    {
        BGMSlider.value = BGMUpdater;
        SFXSlider.value = SFXUpdater;
        MasterVolumeSlider.value = MasterVolumeUpdater;
    }

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
    private void Update()
    {
        MasterVolumeSet(); BGMVolumeSet(); SFXVolumeSet();
        
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
            Pause = true;
            PauseMenuPanel.SetActive(true);
        }
        else
        {
            if(PauseMenuPanel.activeSelf == false) ;
                Pause = true;
        }

    }
    #endregion
}
