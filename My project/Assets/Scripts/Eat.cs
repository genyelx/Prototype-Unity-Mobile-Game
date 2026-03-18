using UnityEngine;

public class Eat : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Can'tEat"))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
