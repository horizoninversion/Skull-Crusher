using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVisibility : MonoBehaviour
{
     private GameObject[] numberOfEnemies;
    private GameObject[] jNumberOfEnemies;
    public GameObject Boss;

    void Update()
    {
        numberOfEnemies = GameObject.FindGameObjectsWithTag("Zombie");
        jNumberOfEnemies = GameObject.FindGameObjectsWithTag("EZ");

        if(numberOfEnemies.Length == 0)
        {
            if(jNumberOfEnemies.Length == 0)
            {
                Boss.SetActive(true);
            }
        }
        
    }
}

