using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
    public GameObject throwingObjectPrefab;
   
    public float speed = 15.0f;
    public float spawnInterwal = 1.0f;
    public Vector2 xRandom;

    [Header("Drop Chance: 0=100%, 1=0%")]
    public float pointsObjectPercentage = 0.1f;                //
    public float damageObjectPercentage = 0.9f;                // definira se postotak spawnanja objekta
    public float lifeObjectPercentage = 1.1f;                  //

    [Header("Dificulty definer")]
    public int difficultyIncrease = 10;                         // definira svakih koliko bodova ce se povecati težina

    public List<GameObject> ThrowingObjects = new List<GameObject>();

    private int _throwingObjectIndex = 0;
    private float _nextSpawn = 0.0f;

    [SerializeField]
    private int _difficultyScore = 0;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        GameManager.onScoreChangedEvent.AddListener(DifficultyIncrease);
        _difficultyScore = difficultyIncrease;
    }


    private void Update()
    {
        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + spawnInterwal;

            ObjectSpawner();
        }
    }
    
    

    private void ObjectSpawner()
    {
        Vector3 randomPositionSpawn = Vector3.zero;
        randomPositionSpawn.x = Random.Range(xRandom.x, xRandom.y);

       // int randomObjectSpawn = Random.Range(0, ThrowingObjects.Count);

        
        if (Random.value > pointsObjectPercentage)
            _throwingObjectIndex = 0;

        else if (Random.value > damageObjectPercentage)
            _throwingObjectIndex = 1;

        else if (Random.value > lifeObjectPercentage)
            _throwingObjectIndex = 2;

        GameObject throwingObjectClone = Instantiate(ThrowingObjects[_throwingObjectIndex], transform.position + randomPositionSpawn, Quaternion.identity) as GameObject;
        _rigidbody2D = throwingObjectClone.GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector2.up * speed;

    }

    private void DifficultyIncrease(int scoreAmount)
    {
        if (scoreAmount >= _difficultyScore)
        {
            if (pointsObjectPercentage >= 0.8f)
            {
                pointsObjectPercentage = 0.8f;
                damageObjectPercentage = 0.2f;

                if (speed <= 21)
                {
                    speed += 1.0f;
                    spawnInterwal -= 0.1f;


                }
                

            }
            else
            {
                pointsObjectPercentage += 0.1f;
                damageObjectPercentage -= 0.1f;
                lifeObjectPercentage -= 0.1f;
                speed += 1.0f;
                spawnInterwal -= 0.1f;
            }
            //TODO: brzina i spawn interval se moraju jos malo smanjiti spawn 0.7 speed 20

            _difficultyScore += difficultyIncrease;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(transform.localScale.x, transform.localScale.y, 0f));

    }
}
