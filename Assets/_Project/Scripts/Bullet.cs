using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage = 50;
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _bulletLifeTime = 3f;

    private Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb == null)
        {
            _rb = gameObject.AddComponent<Rigidbody>();
            _rb.mass = 0.005f;
        }
    }

    private void Start()
    {
        _rb.velocity = transform.forward * _speed;
        Destroy(gameObject, _bulletLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Provo a prendere il componente LifeController dell'oggetto
        // che è entrato nel trigger. Se non ce l'ha, target sarà null
        LifeController target = other.GetComponent<LifeController>();

        // Se target NON è null, significa che l'oggetto può subire danni.
        if (target)
        {
            // Applico il danno chiamando la funzione TakeDamage
            // e passo il valore di damage definito in questo script.
            target.TakeDamage(_damage);
        }
        // Stampo in console il nome dell'oggetto colpito
        Debug.Log($"Hai colpito {other.gameObject.name}");

        // Distruggo il bullet dopo aver colpito qualcosa.
        Destroy(gameObject);
    }
}
