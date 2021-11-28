using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVisibility : MonoBehaviour
{

    private GameObject[] numberOfEnemies;
    private GameObject[] jNumberOfEnemies;
    public GameObject elevator;
    public GameObject elevatorTrigger;
    
    void Update()
    {
        numberOfEnemies = GameObject.FindGameObjectsWithTag("Zombie");
        jNumberOfEnemies = GameObject.FindGameObjectsWithTag("EZ");

        if(numberOfEnemies.Length == 0)
        {
            if(jNumberOfEnemies.Length == 0)
            {
                elevator.SetActive(true);
                elevatorTrigger.SetActive(true);
            }
        }
        
    }
}
