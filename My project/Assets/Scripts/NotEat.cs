using UnityEngine;

public class NotEat : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CanEat"))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
