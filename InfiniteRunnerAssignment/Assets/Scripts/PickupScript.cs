using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public GameObject pickup;

    public float pickupSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pickup.transform.Translate(new Vector2(-1,0) * pickupSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        
    }
}
