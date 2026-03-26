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
    PlayerManager playerManager;

    private void Awake()
    {
        playerManager = FindAnyObjectByType<PlayerManager>();
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
        playerManager.sourceEffects.PlayOneShot(playerManager.audioClips[12]);
    }

    void CloseSettings()
    {
        panelSettings.SetActive(false);
        playerManager.sourceEffects.PlayOneShot(playerManager.audioClips[12]);
    }

    void ExitGame()
    {
        playerManager.sourceEffects.PlayOneShot(playerManager.audioClips[12]);
        SceneManager.LoadScene(0);
    }
}
