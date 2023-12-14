using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public int animalHunger;

    private void Start()
    {
        animalHunger = 5;
    }

    private void Update()
    {
        if (animalHunger <= 0)
        {
            Debug.Log("The Animal has been fed and chooses to die");
            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Food"))
        {
            Debug.Log("Collided with food, hunger is reduced to" + animalHunger);
            animalHunger--;
            Destroy(other.gameObject);

        }
    }
}
