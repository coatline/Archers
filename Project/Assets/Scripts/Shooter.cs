using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] ArcherMove movement;
    [SerializeField] Transform fireArea;
    [SerializeField] Pickuper p;
    Bow bow;

    float timer;

    private void Awake()
    {
        p.RegisterPickedUp(ChangeBow);
    }

    public void Shoot()
    {
        if (!bow) return;

        if (timer >= bow.ReloadDelay)
        {
            timer = 0;
            Fire();
        }
        else
            timer += Time.deltaTime;
    }

    void ChangeBow(Pickup b)
    {
        bow = b.data;
    }

    void Fire()
    {
        // Shoot an arrow
        bow.ShootArrow(fireArea, movement.Direction);
    }

    void Update()
    {
        timer += Time.deltaTime;
    }
}
