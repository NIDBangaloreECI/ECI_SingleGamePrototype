using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintsManager : MonoBehaviour
{
    public GameObject[] Hintprefab; // This is our prefab object that will be exposed in the inspector

    private int numberToCreate; // number of objects to create. Exposed in inspector

    void Start()
    {
        numberToCreate = Hintprefab.Length;

        Populate();
    }

    void Update()
    {



    }

    void Populate()
    {

        for (int i = 0; i < numberToCreate; i++)
        {
            // Create new instances of our prefab until we've created as many as we specified
           Instantiate(Hintprefab[i], transform);
        }

    }
}
