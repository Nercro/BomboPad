using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform Player;
    public GameObject throwingObjectPrefab;
    public float distance = 100f;
    public int numOfObject = 10;
    public float speed = 15f;
    public float spawnInterwal = 1.0f;
    public Vector2 xRandom;
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
        Vector3 randomSpawn = Vector3.zero;
        randomSpawn.x = Random.Range(xRandom.x, xRandom.y);

        GameObject throwingObjectClone = Instantiate(throwingObjectPrefab,transform.position, Quaternion.identity) as GameObject;
        _rigidbody2D = throwingObjectClone.GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector2.MoveTowards(throwingObjectClone.transform.position, Player.transform.position, distance) * speed * Time.deltaTime;
        //throwingObjectClone.transform.Translate(Vector3.MoveTowards())
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(transform.localScale.x, transform.localScale.y, 0f));

    }
}
