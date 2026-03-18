using UnityEngine;

public class Eat : MonoBehaviour
{
    PlayerHealth playerhealth;
    
    private void Start()
    {
        playerhealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Can'tEat"))
        {
            Destroy(collision.gameObject);
            playerhealth.health -= 1;
            playerhealth.points -= 10;
        }
        else
        {
            Destroy(collision.gameObject);
            playerhealth.points += 10 ;
        }
    }
}
