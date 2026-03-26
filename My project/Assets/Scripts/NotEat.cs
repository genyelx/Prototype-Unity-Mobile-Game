using UnityEngine;

public class NotEat : MonoBehaviour
{

    PlayerManager playerManager;
    SpawnItem spawnItem;
    ParticleInstantiate particleInstantiate;

    private void Start()
    {
        playerManager = FindAnyObjectByType<PlayerManager>();
        spawnItem = FindAnyObjectByType<SpawnItem>();
        particleInstantiate = FindAnyObjectByType<ParticleInstantiate>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CanEat"))
        {
            Destroy(collision.gameObject);
            playerManager.points -= 10;
            playerManager.UiUpdatePoints();
            playerManager.UiUpdateLife();
            playerManager.sourceEffects.PlayOneShot(playerManager.audioClips[9]);
            spawnItem.SpawnPrefab();
            particleInstantiate.SpawnParticle(new Vector3(-0.2f, 1.35f, transform.position.z), 1);
        }
        else
        {
            Destroy(collision.gameObject);
            playerManager.points += 10;
            spawnItem.SpawnPrefab();
            playerManager.InscreasePoints();
            playerManager.sourceEffects.PlayOneShot(playerManager.audioClips[9]);
            particleInstantiate.SpawnParticle(new Vector3(-0.2f, 1.35f, transform.position.z), 1);
        }
    }
}
