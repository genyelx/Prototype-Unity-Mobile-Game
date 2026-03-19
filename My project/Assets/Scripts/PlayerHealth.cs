using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject[] Hearts;
    [SerializeField] Text textPoints;
    public int health;
    public int points;

    CameraShake cameraShake;

    void Start()
    {
        cameraShake = FindAnyObjectByType<CameraShake>();
        health = 3;
        points = 0;
    }

    private void Update()
    {
        textPoints.text = "POINTS: " + points.ToString();
    }

    public void UiUpdate()
    {

        if(health > 0)
        {
            ScreenUpdate();
            print("Your health is: " + health);
            StartCoroutine(cameraShake.Shake(0.2f));
        }
        
        if(health <= 0)
        {
            print("Game Over");
            Hearts[0].SetActive(false);
        }

    }

    void ScreenUpdate()
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
 