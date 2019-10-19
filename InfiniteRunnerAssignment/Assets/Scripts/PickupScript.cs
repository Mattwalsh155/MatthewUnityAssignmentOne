using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public GameObject pickup;

    public float pickupSpeed;

    private float pickupPos = -7;

    // Update is called once per frame
    void Update()
    {
        pickup.transform.Translate(new Vector2(-1,0) * pickupSpeed * Time.deltaTime);

        if (pickup.transform.position.x <= pickupPos)
        {
            DestroyPickup();
        }
    }

    public void DestroyPickup()
    {
        Destroy(this.gameObject);
    }
}
