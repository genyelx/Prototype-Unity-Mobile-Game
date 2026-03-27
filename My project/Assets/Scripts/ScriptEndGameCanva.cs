using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptEndGameCanva : MonoBehaviour
{
    [Header("Reference Items")]
    [SerializeField] Button buttonTryAgainGame;
    [SerializeField] Button buttonBackToMenuGame;

    private void Start()
    {
        buttonTryAgainGame.onClick.AddListener(StartGame);
        buttonBackToMenuGame.onClick.AddListener(BackToMenu);
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
        print("Banana");
    }

    void BackToMenu()
    {
        SceneManager.LoadScene(0);
        print("Banana12");
    }
}
