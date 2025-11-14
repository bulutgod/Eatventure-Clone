using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CookStation : MonoBehaviour
{
    public GameObject foodPrefab;
    public Transform spawnPoint;

    public float cookTime = 2.0f;
    private float timer = 0.0f;
    private GameObject readyFood = null;

    private void Update()
    {
        Debug.Log("Update Çalýþýyor! Timer: " + timer);
        if (readyFood = null)
        {
            Debug.Log("Tezgah boþ, timer artýyor...");
            timer += Time.deltaTime;

            if (timer >= cookTime)
            {
                Debug.Log("Süre doldu, SpawnFood() çaðrýlýyor!");
                SpawnFood();
                timer = 0.0f;
            }
        }
    }

    void SpawnFood()
    {
        Instantiate(foodPrefab, spawnPoint.position, Quaternion.identity);
    }

    public GameObject TakeFood()
    {
        if(readyFood != null)
        {
            GameObject foodToGive = readyFood;
            readyFood = null;
            return foodToGive;
        }
        return null;
    }
}
