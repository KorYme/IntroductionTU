using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    private PowerUpType _powerUpType;

    protected override void TriggerEffect()
    {
        if (_entity != null) {
            _powerUpType = (PowerUpType)Random.Range(0, 3);
            Debug.Log("TriggerEffect Power Up");
            switch (_powerUpType) {
                case PowerUpType.Health:
                    _entity.GetComponent<EntityHealth>().IncreaseMaxHealth(10);
                    break;
                case PowerUpType.Speed:
                    _entity.GetComponent<PlayerMove>().IncreaseMaxSpeed(0.1f);
                    break;
                case PowerUpType.Damage:
                    //_entity.GetComponent<PlayerAttack>().IncreaseDamage(1);
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}

public enum PowerUpType
{
    None = -1,
    Health = 0,
    Speed = 1,
    Damage = 2,
}