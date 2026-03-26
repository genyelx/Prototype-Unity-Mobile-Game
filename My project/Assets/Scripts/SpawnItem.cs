using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] GameObject []prefabFood;
    [SerializeField] Transform tranformSpawnItem;
    [SerializeField] Text textNameItem;
    PlayerManager playerManager;
    

    private void Awake()
    {
        tranformSpawnItem = GetComponent<Transform>();
        playerManager = FindAnyObjectByType<PlayerManager>();
    }

    private void Start()
    {
        Instantiate(prefabFood[Random.Range(0, 23)], new Vector3(tranformSpawnItem.position.x, tranformSpawnItem.position.y, tranformSpawnItem.position.z), Quaternion.identity);
        textNameItem.text = "Where yo'll put the item?";
    }

    public void SpawnPrefab()
    {
        playerManager.sourceEffects.PlayOneShot(playerManager.audioClips[10]);
        GameObject newItem;

        if(prefabFood != null)
        {
            if(tranformSpawnItem != null)
            {
                newItem = Instantiate(prefabFood[Random.Range(0, 23)], new Vector3(tranformSpawnItem.position.x, tranformSpawnItem.position.y, tranformSpawnItem.position.z), Quaternion.identity);
                string cleanName = newItem.name.Replace("(Clone)", "").TrimEnd();
                textNameItem.text = cleanName;
                textNameItem.gameObject.SetActive(true);
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
