using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    
    public GameObject Target {
        get { return _target; }
        private set { _target = value; }
    }

    [SerializeField] private TMP_Text _goldText;
    private EntityGold _entityGold;

    void Start()
    {
        _entityGold = Target.GetComponent<EntityGold>();
    }

    void Update()
    {
        _goldText.text = _entityGold.Gold.ToString();
        if (_goldText.text.Length < 3)
            _goldText.text = _goldText.text.PadLeft(3, '0');
        _goldText.text = "Gold " + _goldText.text;
    }
}
