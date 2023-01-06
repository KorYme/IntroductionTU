using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Item
{
    private int value = 0;

    protected override void TriggerEffect()
    {
        if (_entity != null) {
            value = Random.Range(1, 10);
            Debug.Log("TriggerEffect Gold");
            GetComponent<EntityGold>().IncreaseGold(value);
            Destroy(gameObject);
        }
    }
}
