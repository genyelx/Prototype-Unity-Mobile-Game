using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptStartGameCanva : MonoBehaviour
{
    [Header("Reference Items")]
    [SerializeField] Button buttonStartGame;
    [SerializeField] Button buttonExitGame;

    private void Start()
    {
        buttonStartGame.onClick.AddListener(StartGame);
        buttonExitGame.onClick.AddListener(ExitGame);
    }
    
    void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
