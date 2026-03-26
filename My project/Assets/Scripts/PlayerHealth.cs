using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Ui var
    [SerializeField] GameObject[] Hearts;
    [SerializeField] Text textPoints;
    [SerializeField] Text textMultiply;

    //Game Var
    public int health;
    public int points;
    int multiplyPoints = 1;

    //sfx var
    [SerializeField] public AudioSource sourceEffects;
    [SerializeField] public AudioClip[] audioClips;

    //reference a script
    CameraShake cameraShake;
    AudioManager audioManager;

    void Start()
    {
        cameraShake = FindAnyObjectByType<CameraShake>();
        audioManager = FindAnyObjectByType<AudioManager>();
        health = 3;
        points = 0;
        textMultiply.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(health <= 0)
        {
            sourceEffects.PlayOneShot(audioClips[11]);
            Invoke("loadDiedScene", 5.0f);
        }
    }

    public void loadDiedScene()
    {
        SceneManager.LoadScene(2);
    }

    public void InscreasePoints()
    {
        int gainPoints = 1 * multiplyPoints;
        points += gainPoints;
        multiplyPoints++;

        print("Win " + gainPoints + " points! The multiply now is: + " + multiplyPoints);

        UiUpdatePoints();

        if(audioManager != null)
        {
            audioManager.IncreaseCombo();
        }

        if(sourceEffects != null && audioClips != null)
        {
            sourceEffects.PlayOneShot(audioClips[1]);
        }
    }

    public void ResetMultiply()
    {
        multiplyPoints = 1;
        UiUpdatePoints();
        sourceEffects.PlayOneShot(audioClips[8]);
    }

    public void UiUpdatePoints()
    {
        if (textPoints != null)
        {
            textPoints.text = "POINTS: " + points.ToString();
        }

        if (textMultiply != null)
        {
            if (multiplyPoints > 1)
            {
                textMultiply.text = "x" + multiplyPoints.ToString();
                textMultiply.color = Color.green;
                textMultiply.gameObject.SetActive(true);
            }
            else
            {
                textMultiply.gameObject.SetActive(false);
            }
        }
    }

    public void UiUpdateLife()
    {
        if(audioManager != null)
        {
            audioManager.BreakCombo();
        }

        ResetMultiply();

        if (health > 0)
        {
            health--;
            ScreenUpdateLife();
            print("Your health is: " + health);
            StartCoroutine(cameraShake.Shake(0.2f));
        }
        
        if(health <= 0)
        {
            print("Game Over");
            Hearts[0].SetActive(false);
        }

    }

    void ScreenUpdateLife()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if(i < health)
            {
                Hearts[i].SetActive(true);
            }
            else
            {
                Hearts[i].SetActive(false);
            }
        }
    }
}
 