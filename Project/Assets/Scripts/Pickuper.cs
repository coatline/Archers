using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickuper : MonoBehaviour
{
    // Todo: Make the pickup lerp towards holding place after throwing out current item

    [SerializeField] SpriteRenderer holder;

    List<Pickup> overPickups;

    public Pickup Holding { get; private set; }

    public Pickup CurrentOver
    {
        get
        {
            if (overPickups.Count == 0) return null;
            return overPickups[0];
        }
    }

    Action<Pickup> PickedUp;
    public void RegisterPickedUp(Action<Pickup> cb) { PickedUp += cb; }

    public void Pickup(Pickup p)
    {
        // If for some reason I picked up nothing, return.
        if (p == null) return;

        // If I am already holding something, drop it.
        if (Holding != null) Drop();

        // Change sprite being shown.
        holder.sprite = p.data.Sprite;
        Holding = p;

        p.PickThisUp(holder.transform);
        PickedUp?.Invoke(p);
    }

    public void Drop()
    {
        if (Holding == null) return;

        Holding.transform.position = holder.transform.position;

        Holding.Drop(transform.rotation.y == 0 ? 1 : -1);
        Holding = null;
    }

    private void Awake()
    {
        overPickups = new List<Pickup>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            Pickup p = collision.gameObject.GetComponent<Pickup>();

            if (Holding == p || overPickups.Contains(p)) { return; }

            overPickups.Add(p);

            if (!Holding)
                Pickup(p);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            overPickups.Remove(collision.gameObject.GetComponent<Pickup>());
        }
    }
}
