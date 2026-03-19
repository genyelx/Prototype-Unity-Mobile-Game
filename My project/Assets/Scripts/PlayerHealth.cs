using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject[] Hearts;
    public int health;
    public int points;

    void Start()
    {
        health = 3;
        points = 0;
    }

    public void Damage()
    {
        if(health > 0)
        {
            ScreenUpdate();
            print("Your health is: " + health);
        }
        
        if(health <= 0)
        {
            print("Game Over");
            Hearts[0].SetActive(false);
        }
    }

    void ScreenUpdate()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if(i < health)
            {
                Hearts[i].SetActive(true);
            }
            else
            {
                Hearts[i].SetActive(false);
            }
        }
    }
}
