using UnityEngine;

public class Eat : MonoBehaviour
{
    PlayerHealth playerhealth;
    SpawnItem spawnItem;

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
        }
        else
        {
            Destroy(collision.gameObject);
            playerhealth.points += 10 ;
            spawnItem.Score();
        }
    }
}
