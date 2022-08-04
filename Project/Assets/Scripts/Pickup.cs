using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject worldColHolder;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Rigidbody2D rb;
    PolygonCollider2D polygonCol;

    public Bow data { get; private set; }

    Action PickedUp;

    public void RegisterOnPickup(Action cb) { PickedUp += cb; }

    public void Float()
    {
        polygonCol.enabled = false;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;
    }

    public void Drop(int dir)
    {
        transform.SetParent(null);
        gameObject.SetActive(true);

        float velY = Rand(0, 1f) < .1f ? Rand(-15f, -5f) : Rand(2f, 4f);

        rb.velocity = new Vector2(dir * Rand(2f, 3f), velY);
        rb.angularVelocity = Rand(-620f, 620f);
    }

    float Rand(float min, float max) => UnityEngine.Random.Range(min, max);

    private void OnEnable()
    {
        if (polygonCol != null)
            polygonCol.enabled = true;

        rb.gravityScale = 1;
    }

    public void PickThisUp(Transform parent)
    {
        PickedUp?.Invoke();
        transform.SetParent(parent);
        gameObject.SetActive(false);
    }

    public void Setup(Bow b, bool enableWorldCollider = false)
    {
        data = b;
        sr.sprite = data.Sprite;

        polygonCol = worldColHolder.AddComponent<PolygonCollider2D>();
        polygonCol.enabled = enableWorldCollider;
    }
}
