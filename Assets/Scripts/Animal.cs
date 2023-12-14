using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!");

        if(other.CompareTag("Food"))
        {
            Debug.Log("Collided with food");
            Destroy(other.gameObject);

        }
    }
}
