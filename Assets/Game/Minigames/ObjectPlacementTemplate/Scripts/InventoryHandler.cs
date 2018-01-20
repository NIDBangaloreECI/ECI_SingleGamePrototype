using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
    public GameObject[] prefab; // This is our prefab array object that will be exposed in the inspector

    private int numberToCreate; // number of objects to create.

    void Start()
    {
        numberToCreate = prefab.Length;

        Populate();
    }

    void Update()
    {

    }

    void Populate()
    {
        GameObject newObj; // Create GameObject instance

        for (int i = 0; i < numberToCreate; i++)
        {
            // Create new instances of our prefab
            newObj = (GameObject)Instantiate(prefab[i], transform);
        }

    }
}