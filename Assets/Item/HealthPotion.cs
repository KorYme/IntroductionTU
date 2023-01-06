using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    protected override void TriggerEffect()
    {
        if (_entity != null) {
            Debug.Log("TriggerEffect Health Potion");
            _entity.GetComponent<EntityHealth>().Heal(1);
            Destroy(gameObject);
        }
    }
}
