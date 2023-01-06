using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private LayerMask _hitLayer;

    [SerializeField]
    private int _damageAmount;

    [Serializable]
    public struct HitBoxPoint
    {
        public Transform _center;
        public float _radius;
    }

    [SerializeField]
    private List<HitBoxPoint> _pointsHitBox = new();

    List<Collider> _collidersAlreadyTouched = new List<Collider>();

    private void Awake()
    {
        Assert.IsTrue(_damageAmount > 0);
        _collidersAlreadyTouched.Clear();
    }



    public void Damage()
    {
        foreach (HitBoxPoint point in _pointsHitBox)
        {
            foreach (Collider collider in Physics.OverlapSphere(point._center.position, point._radius))
            {
                if (_collidersAlreadyTouched.Contains(collider)) return;
                _collidersAlreadyTouched.Add(collider);
                collider.GetComponent<EntityHealth>().TakeDamage(_damageAmount);
            }
        }
    }

    public void EmptyListColliders()
    {
        _collidersAlreadyTouched.Clear();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (HitBoxPoint point in _pointsHitBox)
        {
            Gizmos.DrawSphere(point._center.position, point._radius);
        }
    }
}
