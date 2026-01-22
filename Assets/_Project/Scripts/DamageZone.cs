using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private float _damage = 20;
    private void OnTriggerEnter(Collider other)
    {
        LifeController target = other.GetComponent<LifeController>();
        if (target)
        {
            target.TakeDamage(_damage);
        }
    }
}
