using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float speed = 10.0f;
    public float xRange = 10;
    public float zRange = 5f;

    public Vector3 bananaSpawnPoint;

    public GameObject projectilePrefab;

    void Start()
    {
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        transform.position += moveDirection * speed * Time.deltaTime;

        //movePlayer
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        if (transform.position.z < -zRange )
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }


        //rotate player to look at mouse (ChatGPT script)
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Set the distance from the camera to the object
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 lookAtDirection = worldPosition - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(lookAtDirection);
        transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);


        //create banana
        if (Input.GetMouseButtonDown(0))
        {
            bananaSpawnPoint = transform.position + new Vector3(0, 0, 0.5f);
            Instantiate(projectilePrefab, bananaSpawnPoint, transform.rotation);
        }
    }
}
