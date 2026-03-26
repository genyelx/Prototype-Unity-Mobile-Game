using UnityEngine;

public class Eat : MonoBehaviour
{
    PlayerManager playerManager;
    SpawnItem spawnItem;
    ParticleInstantiate particleIntantiate;

    private void Start()
    {
        playerManager = FindAnyObjectByType<PlayerManager>();
        spawnItem = FindAnyObjectByType<SpawnItem>();
        particleIntantiate = FindAnyObjectByType<ParticleInstantiate>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Can'tEat"))
        {
            Destroy(collision.gameObject);
            playerManager.points -= 10;
            playerManager.UiUpdatePoints();
            playerManager.UiUpdateLife();
            playerManager.sourceEffects.PlayOneShot(playerManager.audioClips[6]);
            spawnItem.SpawnPrefab();
            particleIntantiate.SpawnParticle(new Vector3(1.2f, 1.35f, transform.position.z), 1);
        }
        else
        {
            Destroy(collision.gameObject);
            playerManager.points += 10 ;
            playerManager.InscreasePoints();
            playerManager.sourceEffects.PlayOneShot(playerManager.audioClips[7]);
            spawnItem.SpawnPrefab();
            particleIntantiate.SpawnParticle(new Vector3(1.2f, 1.35f, transform.position.z), 0);
        }
    }
}
