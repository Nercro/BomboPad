using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
    public GameObject throwingObjectPrefab;
   
    public int numOfObject = 10;
    public float speed = 15.0f;
    public float spawnInterwal = 1.0f;
    public Vector2 xRandom;

    public List<GameObject> ThrowingObjects = new List<GameObject>();

    private Rigidbody2D _rigidbody2D;
    

    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        for (int i = 0; i < numOfObject; i++)
        {
            ObjectSpawner();

            yield return new WaitForSeconds(spawnInterwal);
        }
    }
    

    private void ObjectSpawner()
    {
        Vector3 randomPositionSpawn = Vector3.zero;
        randomPositionSpawn.x = Random.Range(xRandom.x, xRandom.y);

        int randomObjectSpawn = Random.Range(0, ThrowingObjects.Count);

        GameObject throwingObjectClone = Instantiate(ThrowingObjects[randomObjectSpawn], transform.position + randomPositionSpawn, Quaternion.identity) as GameObject;
        _rigidbody2D = throwingObjectClone.GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector2.up * speed * Time.deltaTime;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(transform.localScale.x, transform.localScale.y, 0f));

    }
}
