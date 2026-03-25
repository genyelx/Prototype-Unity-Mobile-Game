using NUnit.Framework.Constraints;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] GameObject []prefabFood;
    [SerializeField] Transform tranformSpawnItem;
    PlayerHealth playerhealth;

    private void Awake()
    {
        tranformSpawnItem = GetComponent<Transform>();
        playerhealth = FindAnyObjectByType<PlayerHealth>();
    }

    private void Start()
    {
        Instantiate(prefabFood[Random.Range(0, 23)], new Vector3(tranformSpawnItem.position.x, tranformSpawnItem.position.y, tranformSpawnItem.position.z), Quaternion.identity);
    }

    public void SpawnPrefab()
    {
        playerhealth.sourceEffects.PlayOneShot(playerhealth.audioClips[10]);

        if(prefabFood != null)
        {
            if(tranformSpawnItem != null)
            {
                Instantiate(prefabFood[Random.Range(0, 23)], new Vector3(tranformSpawnItem.position.x, tranformSpawnItem.position.y, tranformSpawnItem.position.z), Quaternion.identity);
            }
            else
            {
                print("The object don't have tranform to spawn the item");
            }
        }
        else
        {
            print("Don't have prefabFood");
        }
        
    }
}
