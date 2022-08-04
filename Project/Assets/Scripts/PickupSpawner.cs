using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] Transform itemHolderTransform;
    [SerializeField] SpriteRenderer glow;
    Pickup pickup;

    void Start()
    {
        Hold(PickupGenerator.I.GetRandomPickup(itemHolderTransform.position));
    }

    void Hold(Pickup p)
    {
        pickup = p;

        p.transform.SetParent(itemHolderTransform);
        p.Float();
        p.RegisterOnPickup(PickedUp);
    }

    void PickedUp()
    {
        glow.enabled = false;
        Destroy(this);
    }

    private void Update()
    {
        if (pickup)
            pickup.transform.position = itemHolderTransform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!pickup)
        {

        }
    }
}
