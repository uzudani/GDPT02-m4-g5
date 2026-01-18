using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private float _hp;
    [SerializeField] private float _maxHp = 200;
    [SerializeField] private UnityEvent<float, float> onHealthChanged;

    private void Start()
    {
        _hp = _maxHp;
        onHealthChanged.Invoke(_hp, _maxHp);
    }

    public void TakeDamage(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Debug.Log("You Died");
            Destroy(gameObject);
        }
        onHealthChanged.Invoke(_hp, _maxHp);
    }
}
