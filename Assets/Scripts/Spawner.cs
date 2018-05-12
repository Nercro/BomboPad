using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
    //[System.Serializable]
    //public class ObjectPerct
    //{
    //    public GameObject Obj;
    //    public float Percent;
    //}
   
    public GameObject throwingObjectsClonesParent;
   
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
    [Header("Read Only!")]
    private int _difficultyScore = 0;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        GameManager.onScoreChangedEvent.AddListener(DifficultyIncrease);
        GameManager.onGameOverEvent.AddListener(OnGameOver);

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
        
        if (Random.value > pointsObjectPercentage)
            _throwingObjectIndex = 0;

        else if (Random.value > damageObjectPercentage)
            _throwingObjectIndex = 1;

        else if (Random.value > lifeObjectPercentage)
            _throwingObjectIndex = 2;

        GameObject throwingObjectClone = Instantiate(ThrowingObjects[_throwingObjectIndex], transform.position + randomPositionSpawn, Quaternion.identity, throwingObjectsClonesParent.transform) as GameObject;
        _rigidbody2D = throwingObjectClone.GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector2.up * speed;
    }

    private void DifficultyIncrease(int scoreAmount)
    {
        // postotsk spawnanja objekta i postavljanje minimalne vrijednosti spawna, speeda, i spawn intervala
        if (scoreAmount >= _difficultyScore)
        {
            if (pointsObjectPercentage >= 0.8f)
            {
                pointsObjectPercentage = 0.8f;
                damageObjectPercentage = 0.2f;

                if (speed <= 13)
                {
                    speed += 0.1f;
                    spawnInterwal -= 0.1f;
                }
            }
            else
            {
                pointsObjectPercentage += 0.1f;
                damageObjectPercentage -= 0.1f;
                lifeObjectPercentage -= 0.1f;
                speed += 0.1f;
                spawnInterwal -= 0.1f;
            }

            _difficultyScore += difficultyIncrease;
        }
    }

    private void OnGameOver(bool isGameOver)
    {
        if (isGameOver)
            Destroy(throwingObjectsClonesParent);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(transform.localScale.x, transform.localScale.y, 0f));

    }
}
