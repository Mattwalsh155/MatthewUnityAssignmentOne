using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject enemy;

    public float enemySpeed;

    private int randNumber;
    private float xPos;
    private float yPos;

    //private int randTime = Random.Range(0,3);
    //private int randRepeat = Random.Range(0,5);

    // Start is called before the first frame update
    void Start()
    {
        // Why don't I just initialize these when I declare the variables?
        xPos = 0;
        yPos = -4;
        // Don't use invoke repeating to spawn enemies
        // InvokeRepeating("SpawnEnemy",3, 20);
    }

    // Update is called once per frame
    void Update()
    {
        enemy.transform.Translate(new Vector2(-1,0) * enemySpeed * Time.deltaTime);
    }

    void SpawnEnemy()
    {
        GameObject temp = Instantiate(enemy, new Vector2(0,0), enemy.transform.rotation);
        xPos -= 1;
        temp.transform.position = new Vector2(xPos,0);
    }

    void DestroyEnemy()
    {
        
    }
}
