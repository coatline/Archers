using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bow", menuName = "Bow")]

public class Bow : ScriptableObject
{
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Vector2 arrowSpeed;
    [SerializeField] float reloadTime;
    [SerializeField] Sprite sprite;
    [SerializeField] int dmg;

    public int Damage { get { return dmg; } }
    public Sprite Sprite { get { return sprite; } }
    public float ReloadDelay { get { return reloadTime; } }
    public Vector2 ArrowSpeed { get { return arrowSpeed; } }

    public GameObject ShootArrow(Transform fireArea, int dir)
    {
        GameObject arrow = Instantiate(arrowPrefab, fireArea.position, Quaternion.identity);
        arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowSpeed.x * dir, arrowSpeed.y);
        arrow.transform.rotation = dir == -1 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        return arrow;
    }
}
