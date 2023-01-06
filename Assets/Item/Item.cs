using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] protected UnityEvent _onPickUp;

    public UnityEvent OnPickUp {
        get { return _onPickUp; }
        private set { _onPickUp = value; }
    }

    protected GameObject _entity;

    protected virtual void TriggerEffect()
    {
        return;
    }

    public void OnTriggerEffect()
    {
        TriggerEffect();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter Collider Name = " + other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            _entity = other.gameObject;
            OnPickUp?.Invoke();
        }
    }
}
