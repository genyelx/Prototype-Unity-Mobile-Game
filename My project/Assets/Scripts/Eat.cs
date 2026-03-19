using UnityEngine;

public class Eat : MonoBehaviour
{
    PlayerHealth playerhealth;
    SpawnItem spawnItem;

    [Header("Particle Prefab")]
    [SerializeField] GameObject particleEat;
    [SerializeField] GameObject particleCannotEat;

    private void Start()
    {
        playerhealth = FindAnyObjectByType<PlayerHealth>();
        spawnItem = FindAnyObjectByType<SpawnItem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Can'tEat"))
        {
            Destroy(collision.gameObject);
            playerhealth.health -= 1;
            playerhealth.points -= 10;
            spawnItem.Score();
            Instantiate(particleCannotEat, new Vector3(1.2f, 1.35f, transform.position.z), Quaternion.identity);
        }
        else
        {
            Destroy(collision.gameObject);
            playerhealth.points += 10 ;
            spawnItem.Score();
            Instantiate(particleEat, new Vector3(1.2f, 1.35f, transform.position.z), Quaternion.identity);
        }
    }
}
