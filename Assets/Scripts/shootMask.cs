using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootMask : MonoBehaviour
{

    [SerializeField] protected KeyCode keyToPress;
    [SerializeField] protected GameObject prefabToSpawn;
    private GameObject clone;
    [SerializeField] protected Vector3 velocityOfSpawnedObject = new Vector3(0, 0, 10);
    [SerializeField] protected float lifeSpan = 1.5f;   

    protected GameObject spawnObject()
    {        
        Vector3 positionOfSpawnedObject = transform.position + new Vector3(0, 0, 13); // span at the containing object position.       
        Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
        GameObject clone = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);        
        Rigidbody instFoamRB = clone.GetComponent<Rigidbody>();
        instFoamRB.AddForce(clone.transform.forward * velocityOfSpawnedObject.z);
        Destroy(clone, lifeSpan);
        return clone;
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress)) {
            clone = spawnObject();           
        }
        if (clone != null) {
            clone.transform.position += velocityOfSpawnedObject;
            clone.transform.Rotate(180*Time.deltaTime, 0, 0);
        } 
       



    }
}
