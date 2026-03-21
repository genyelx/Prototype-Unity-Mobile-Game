using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvaManager : MonoBehaviour
{
    [Header("Reference Items")]
    [SerializeField] Button buttonOpenSettings;
    [SerializeField] GameObject panelSettings;
    [SerializeField] Button buttonCloseSettings;
    [SerializeField] Button buttonExitGame;
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSound;

    //reference Scripts
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void Start()
    {
        panelSettings.SetActive(false);
        buttonOpenSettings.onClick.AddListener(OpenSettings);
        buttonCloseSettings.onClick.AddListener(CloseSettings);
        buttonExitGame.onClick.AddListener(ExitGame);
    }

    void OpenSettings()
    {
        panelSettings.SetActive(true);
    }

    void CloseSettings()
    {
        panelSettings.SetActive(false);
    }

    void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
