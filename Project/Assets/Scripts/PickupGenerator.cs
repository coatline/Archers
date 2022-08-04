using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGenerator : MonoBehaviour
{
    [SerializeField] List<Bow> bowDatas;
    [SerializeField] Pickup pickupPrefab;

    public Bow RandBowData()
    {
        return bowDatas[Random.Range(0, bowDatas.Count)];
    }

    public Pickup GetRandomPickup(Vector3 pos)
    {
        Pickup p = Instantiate(pickupPrefab, pos, Quaternion.identity);
        p.Setup(bowDatas[Random.Range(0,bowDatas.Count)]);
        return p;
    }

    private void Awake()
    {
        instance = this;
    }

    #region Statics
    static PickupGenerator instance;
    public static PickupGenerator I
    {
        get
        {
            if (instance == null)
            {
                var gob = new GameObject("BowGenerator");
                gob.AddComponent<PickupGenerator>();
            }

            return instance;
        }
    }
    #endregion
}
