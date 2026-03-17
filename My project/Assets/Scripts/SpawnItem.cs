using NUnit.Framework.Constraints;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] GameObject []prefabFood;
    [SerializeField] Transform tranformSpawnItem;

    private bool haveInstantiate;

    private void Awake()
    {
        tranformSpawnItem = GetComponent<Transform>();
    }

    void Start()
    {
      
    }

    void Instantiate()
    {
        Instantiate(prefabFood[Random.Range(0, 23)], new Vector3(tranformSpawnItem.position.x, tranformSpawnItem.position.y, tranformSpawnItem.position.z), Quaternion.identity);
    }
}
