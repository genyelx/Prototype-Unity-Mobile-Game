using UnityEngine;

public class NotEat : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CanEat"))
        {
            Destroy(collision.gameObject);
            PlayerHealth.health -= 1;
            PlayerHealth.points -= 10;
        }
        else
        {
            Destroy(collision.gameObject);
            PlayerHealth.points += 10;
        }
    }
}
