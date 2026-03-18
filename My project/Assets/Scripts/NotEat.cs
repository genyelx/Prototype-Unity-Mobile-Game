using UnityEngine;

public class NotEat : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CanEat"))
        {
            Destroy(collision.gameObject);
            playerhealth.health -= 1;
            playerhealth.points -= 10;
        }
        else
        {
            Destroy(collision.gameObject);
            playerhealth.points += 10;
        }
    }
}
