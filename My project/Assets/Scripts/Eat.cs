using UnityEngine;

public class Eat : MonoBehaviour
{
    PlayerHealth playerhealth;
    SpawnItem spawnItem;
    ParticleInstantiate particleIntantiate;

    private void Start()
    {
        playerhealth = FindAnyObjectByType<PlayerHealth>();
        spawnItem = FindAnyObjectByType<SpawnItem>();
        particleIntantiate = FindAnyObjectByType<ParticleInstantiate>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Can'tEat"))
        {
            Destroy(collision.gameObject);
            playerhealth.health -= 1;
            playerhealth.points -= 10;
            playerhealth.UiUpdate();
            spawnItem.SpawnPrefab();
            particleIntantiate.SpawnParticle(new Vector3(1.2f, 1.35f, transform.position.z), 1);
        }
        else
        {
            Destroy(collision.gameObject);
            playerhealth.points += 10 ;
            spawnItem.SpawnPrefab();
            particleIntantiate.SpawnParticle(new Vector3(1.2f, 1.35f, transform.position.z), 0);
        }
    }
}
