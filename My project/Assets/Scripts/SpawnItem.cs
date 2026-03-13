using NUnit.Framework.Constraints;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] GameObject []prefabFood;

    Transform tranformSpawnItem;

    private void Awake()
    {
        tranformSpawnItem = GetComponent<Transform>();
    }

    void Start()
    {
        Instantiate(prefabFood[Random.Range(0, 23)], new Vector3(0.5f, 1.5f, -8.5f), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
