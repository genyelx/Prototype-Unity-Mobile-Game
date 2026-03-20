using UnityEngine;

public class NotEat : MonoBehaviour
{

    PlayerHealth playerhealth;
    SpawnItem spawnItem;
    ParticleInstantiate particleInstantiate;

    private void Start()
    {
        playerhealth = FindAnyObjectByType<PlayerHealth>();
        spawnItem = FindAnyObjectByType<SpawnItem>();
        particleInstantiate = FindAnyObjectByType<ParticleInstantiate>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CanEat"))
        {
            Destroy(collision.gameObject);
            playerhealth.points -= 10;
            playerhealth.UiUpdatePoints();
            playerhealth.UiUpdateLife();
            spawnItem.SpawnPrefab();
            particleInstantiate.SpawnParticle(new Vector3(-0.2f, 1.35f, transform.position.z), 1);
        }
        else
        {
            Destroy(collision.gameObject);
            playerhealth.points += 10;
            spawnItem.SpawnPrefab();
            playerhealth.InscreasePoints();
            particleInstantiate.SpawnParticle(new Vector3(-0.2f, 1.35f, transform.position.z), 1);
        }
    }
}
