using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public GameObject[] background;

    public float bgSpeed;

    private float bgPosLeft = -28;
    private float bgPosRight = 60.98f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < background.Length; i++)
        {

        background[i].transform.Translate(new Vector2(-1,0) * bgSpeed * Time.deltaTime);

        //Debug.Log(background[1].transform.position.x);
        // do something like this to destroy the enemy and pickup
        if (background[i].transform.position.x <= bgPosLeft)
            {
                background[i].transform.position = new Vector3(bgPosRight,background[i].transform.position.y,background[i].transform.position.z);
            }
        }

         
        // else if ()

        // position.x when background image moves off screen = -28

        // for(int i = 0; i < floor.Length; i++)
        // {
        //     floor[i].transform.Translate(new Vector3(-1,0,0) * floorSpeed * Time.deltaTime);
        //     // Check the floor x position so we know when it's off the screen to the left here
        //     // Reset the floor position to off the screen to the right side if so.
        //     // floor[i].transform.position = "the position off screen on the right"
        //     // debug floor transform.position.x
        // }
    }
}
