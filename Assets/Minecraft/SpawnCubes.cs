using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject[] spawnObject;
    private GameObject tempObject;
    public int selectedSpawnIndex = 0;

    public Vector3 vectorUp = new Vector3(0, 0, 1);
    public Vector3 vectorDown = new Vector3(0, 0, -1);
    public Vector3 vectorRight = new Vector3(1, 0, 0);
    public Vector3 vectorLeft = new Vector3(-1, 0, 0);
  

    void Update()
    {
        moveSpawnCube();
        spawnAnObject();
        changeSpawnType();
        //delete spawn in location ?? destroy
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Youve collided, lets delete it and prevent you from putting things here!");
    }

    private void spawnAnObject()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tempObject = Instantiate(spawnObject[selectedSpawnIndex], transform.position, transform.rotation);
        }
    }
    private void moveSpawnCube()
    {
        if (Input.GetKeyDown("up") && transform.position.z < 4)
        {
            transform.Translate(vectorUp);
        }
        if (Input.GetKeyDown("down") && transform.position.z > -4)
        {
            transform.Translate(vectorDown);
        }
        if (Input.GetKeyDown("right") && transform.position.x < 4)
        {
            transform.Translate(vectorRight);
        }
        if (Input.GetKeyDown("left") && transform.position.x > -4)
        {
            transform.Translate(vectorLeft);
        }
    }
    private void changeSpawnType()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            iterateSpawnObjectIndex();
            updateSpawnCubeMaterial();
        }
    }

    private void updateSpawnCubeMaterial()
    {
        GetComponent<MeshRenderer>().sharedMaterial = spawnObject[selectedSpawnIndex].GetComponent<MeshRenderer>().sharedMaterial;
    }

    private void iterateSpawnObjectIndex()
    {
        selectedSpawnIndex = (selectedSpawnIndex + 1) % spawnObject.Length;
    }
}
