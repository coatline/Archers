using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] ArcherMove movement;
    [SerializeField] Pickuper pickuper;
    [SerializeField] Shooter shooter;

    void Update()
    {
        Movements();
        Inputs();
    }

    void Movements()
    {
        var x = Input.GetAxisRaw("Horizontal");

        movement.Move(x);
    }

    void Inputs()
    {
        // Shoot
        if (Input.GetMouseButton(0))
            shooter.Shoot();

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
            movement.TryJump();

        if (Input.GetKeyDown(KeyCode.E))
            pickuper.Pickup(pickuper.CurrentOver);
    }
}
