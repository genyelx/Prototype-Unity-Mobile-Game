using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public int comboActual = 0;
    float increaseToPoints = 0.005f;
    float speedMax = 1.5f;
    float speedNormal = 1.0f;

    PlayerHealth playerHealth;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        audioSource.pitch = speedNormal;
    }

    public void IncreaseCombo()
    {
        comboActual++;
        float newVelocity = speedNormal + (comboActual * increaseToPoints);
        audioSource.pitch = Mathf.Min(newVelocity, speedMax);
        print("Combo: " + comboActual + "| Speed: " + audioSource.pitch);
        if (comboActual <= 5)
        {
            playerHealth.sourceEffects.PlayOneShot(playerHealth.audioClips[2]);
        }
        else if (comboActual <= 10)
        {
            playerHealth.sourceEffects.PlayOneShot(playerHealth.audioClips[3]);
        }
        else if(comboActual <= 15)
        {
            playerHealth.sourceEffects.PlayOneShot(playerHealth.audioClips[4]);
        }
        else
        {
            playerHealth.sourceEffects.PlayOneShot(playerHealth.audioClips[5]);
        }
    }

    public void BreakCombo()
    {
        comboActual = 0;
        audioSource.pitch = speedNormal;
        print("Break Combo!");
    }
}
