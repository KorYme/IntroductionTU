using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class HitEntity : MonoBehaviour
{
    [SerializeField]
    protected int _damageAmount;

    protected List<Collider> _collidersAlreadyTouched = new List<Collider>();

    private void OnTriggerStay(Collider other)
    {
        if (!_collidersAlreadyTouched.Contains(other))
        {
            _collidersAlreadyTouched.Add(other);
            other.GetComponent<EntityHealth>()?.TakeDamage(_damageAmount);
        }
    }

    public void EmptyListColliders()
    {
        _collidersAlreadyTouched.Clear();
    }
}