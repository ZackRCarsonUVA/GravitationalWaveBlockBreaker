using UnityEngine;

public class BlackHoleManager : MonoBehaviour
{
    public GameObject blackHolePrefab; // Reference to your BlackHoles prefab
    public int numberOfBlackHoles = 5;

    void Start()
    {
        for (int i = 0; i < numberOfBlackHoles; i++)
        {
            GameObject newBlackHole = Instantiate(blackHolePrefab, GetRandomPosition(), Quaternion.identity);
            
        }
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-50f, 50f);
        float y = Random.Range(-50f, 50f);

        return new Vector3(x, y, 0f);
    }
}