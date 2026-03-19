using UnityEngine;

public class NotEat : MonoBehaviour
{

    PlayerHealth playerhealth;
    SpawnItem spawnItem;
    [SerializeField] GameObject particleCannotEat;

    private void Start()
    {
        playerhealth = FindAnyObjectByType<PlayerHealth>();
        spawnItem = FindAnyObjectByType<SpawnItem>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CanEat"))
        {
            Destroy(collision.gameObject);
            playerhealth.health -= 1;
            playerhealth.points -= 10;
            spawnItem.Score();
            Instantiate(particleCannotEat, new Vector3(-0.2f, 1.35f, transform.position.z), Quaternion.identity);
        }
        else
        {
            Destroy(collision.gameObject);
            playerhealth.points += 10;
            spawnItem.Score();
            Instantiate(particleCannotEat, new Vector3(-0.2f, 1.35f, transform.position.z), Quaternion.identity);
        }
    }
}
