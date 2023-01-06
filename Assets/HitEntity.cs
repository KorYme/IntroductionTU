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

    private void OnTriggerEnter(Collider other)
    {
        if (_collidersAlreadyTouched.Contains(other)) return;
        _collidersAlreadyTouched.Add(other);
        Transform current = other.transform;
        while (current.parent != null)
        {
            if (current.parent.GetComponent<EntityHealth>())
            {
                current.parent.GetComponent<EntityHealth>().TakeDamage(_damageAmount);
                return;
            }
            current = current.transform.parent;
        }
    }

    public void EmptyListColliders()
    {
        _collidersAlreadyTouched.Clear();
    }
}