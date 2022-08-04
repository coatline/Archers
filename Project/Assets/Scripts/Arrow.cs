using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] float lifeTime;

    private void Start()
    {
        StartCoroutine(DoLife());
    }

    IEnumerator DoLife()
    {
        yield return new WaitForSeconds(lifeTime);
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        sr.color -= new Color(0, 0, 0, Time.deltaTime);
        yield return new WaitForEndOfFrame();

        if (sr.color.a <= 0)
            Destroy(gameObject);
        else
            StartCoroutine(Die());
    }
}
