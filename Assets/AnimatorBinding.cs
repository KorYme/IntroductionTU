using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBinding : MonoBehaviour
{
    private Animator _animator;

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
}