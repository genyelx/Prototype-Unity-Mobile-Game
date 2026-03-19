using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public int comboActual = 0;
    float increaseToPoints = 0.005f;
    float speedMax = 1.5f;
    float speedNormal = 1.0f;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = speedNormal;
    }

    public void IncreaseCombo()
    {
        comboActual++;
        float newVelocity = speedNormal + (comboActual * increaseToPoints);
        audioSource.pitch = Mathf.Min(newVelocity, speedMax);
        print("Combo: " + comboActual + "| Speed: " + audioSource.pitch);
    }

    public void BreakCombo()
    {
        comboActual = 0;
        audioSource.pitch = speedNormal;
        print("Break Combo!");
    }
}
