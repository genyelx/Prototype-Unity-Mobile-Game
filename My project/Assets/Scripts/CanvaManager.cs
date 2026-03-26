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
    PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();
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
        playerHealth.sourceEffects.PlayOneShot(playerHealth.audioClips[12]);
    }

    void CloseSettings()
    {
        panelSettings.SetActive(false);
        playerHealth.sourceEffects.PlayOneShot(playerHealth.audioClips[12]);
    }

    void ExitGame()
    {
        playerHealth.sourceEffects.PlayOneShot(playerHealth.audioClips[12]);
        SceneManager.LoadScene(0);
    }
}
