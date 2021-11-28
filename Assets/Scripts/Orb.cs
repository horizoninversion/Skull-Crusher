using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{

    private GameObject[] numberOfEnemies;
    private GameObject[] jNumberOfEnemies;
    public GameObject orb;

    void Update()
    {
        numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        jNumberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy2");

        if(numberOfEnemies.Length == 0)
        {
            if(jNumberOfEnemies.Length == 0)
            {
                orb.SetActive(true);
            }
        }
        
    }
}
