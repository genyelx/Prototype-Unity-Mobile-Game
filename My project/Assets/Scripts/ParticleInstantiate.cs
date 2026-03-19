using UnityEngine;

public class ParticleInstantiate : MonoBehaviour
{
    [SerializeField]GameObject[] particlePrefab;

    public void SpawnParticle(Vector3 position, int particleNumber)
    {
        if(particlePrefab != null)
        {
            GameObject particleCreated = Instantiate(particlePrefab[particleNumber], position, Quaternion.identity);
            Destroy(particleCreated, 1.5f);
        }
    }
}
