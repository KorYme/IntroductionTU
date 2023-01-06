using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorBinding : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] UnityEvent _onApplyDamage;
    [SerializeField] UnityEvent _onStopDamage;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void GetHit()
    {
        _animator.SetTrigger("GetHit");
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }

    public void Walking(bool walking)
    {
        _animator.SetBool("Walking", walking);
    }

    public void ApplyDamage()
    {
        _onApplyDamage?.Invoke();
    }

    public void ApplyStopDamage()
    {
        _onStopDamage?.Invoke();
    }
}