using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public int comboActual = 0;
    float increaseToPoints = 0.005f;
    float speedMax = 1.5f;
    float speedNormal = 1.0f;

    PlayerManager playerManager;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerManager = FindAnyObjectByType<PlayerManager>();
        audioSource.pitch = speedNormal;
    }

    public void IncreaseCombo()
    {
        comboActual++;
        float newVelocity = speedNormal + (comboActual * increaseToPoints);
        audioSource.pitch = Mathf.Min(newVelocity, speedMax);
        if (comboActual <= 5)
        {
            playerManager.sourceEffects.PlayOneShot(playerManager.audioClips[2]);
        }
        else if (comboActual <= 10)
        {
            playerManager.sourceEffects.PlayOneShot(playerManager.audioClips[3]);
        }
        else if(comboActual <= 15)
        {
            playerManager.sourceEffects.PlayOneShot(playerManager.audioClips[4]);
        }
        else
        {
            playerManager.sourceEffects.PlayOneShot(playerManager.audioClips[5]);
        }
    }

    public void BreakCombo()
    {
        comboActual = 0;
        audioSource.pitch = speedNormal;
    }
}
