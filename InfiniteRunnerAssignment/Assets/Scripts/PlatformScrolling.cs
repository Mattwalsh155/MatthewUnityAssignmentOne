using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScrolling : MonoBehaviour
{
    public GameObject[] platforms;

    public float platformSpeed;
    public float platformPosLeft;
    public float platformPosRight;

    private int randNumber;

    private float xPos;
    private float yPos;

    // Start is called before the first frame update
    void Start()
    {
        randNumber = 0;
        xPos = 0;
        yPos = -4;
        //InvokeRepeating("SpawnPlatforms",1,5);
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnPlatforms();

        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].transform.Translate(new Vector2(-1,0) * platformSpeed * Time.deltaTime);

            //Debug.Log(platforms[1].transform.position.x);
        }
    }

    public void SpawnPlatforms()
    {
        randNumber = Random.Range(0,3);
        GameObject temp = Instantiate(platforms[randNumber], new Vector2(0,0), platforms[randNumber].transform.rotation);
        xPos -= 1;
        temp.transform.position = new Vector2(xPos,yPos);
    }
}
