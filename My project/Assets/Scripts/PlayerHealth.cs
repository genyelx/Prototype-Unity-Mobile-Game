using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int points;

    void Start()
    {
        health = 3;
        points = 0;
    }

    private void Update()
    {
        print(health);
        print(points);
    }
}
