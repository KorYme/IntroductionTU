using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityGold : MonoBehaviour
{
    private int _gold;

    public int Gold {
        get { return _gold; }
        private set { _gold = value; }
    }

    public void IncreaseGold(int value)
    {
        Gold += value;
    }
}
