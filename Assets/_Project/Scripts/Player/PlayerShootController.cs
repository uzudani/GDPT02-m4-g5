using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _raycastRange = 1000;
    [SerializeField] private LayerMask _raycastMask; // Escludo layer inutili

    private float nextFireTime = 0f;

    void Update()
    {
        BulletLogic();
    }

    private void BulletLogic()
    {
        // Sparo solo se il tasto sinistro è premuto
        // e se è passato abbastanza tempo dall'ultimo sparo (fire rate).
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            // Creo un Ray che parte dalla camera e passa per la posizione del mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 direction;

            // Se il Raycast colpisce qualcosa
            if (Physics.Raycast(ray, out RaycastHit hit, _raycastRange))
            {
                // Direzione verso il punto colpito
                direction = (hit.point - _shootPoint.position).normalized;
            }
            else
            {
                // Se non colpisce nulla sparo comunque nella direzione del Ray
                direction = ray.direction;
            }

            // Sparo SEMPRE
            Shoot(direction);

            // Imposto il prossimo momento in cui sarà possibile sparare
            nextFireTime = Time.time + _fireRate;
        }
    }
    private void Shoot(Vector3 direction)
    {
        // Istanzio il bullet
        GameObject bullet = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.LookRotation(direction));

        // Ignoro il collider del Player
        Collider playerCollider = GetComponent<Collider>();
        Collider bulletCollider = bullet.GetComponent<Collider>();

        if (playerCollider && bulletCollider) // != null
        {
            Physics.IgnoreCollision(bulletCollider, playerCollider);
        }
    }
}

// Time.time = tempo tale trascorso da inizio scena
// nextFireTime = prossimo momento in cui e' permesso sparare
// fireRate = puoi sparare ogni tot tempo stabilito
// nextFireTime = Time.time + fireRate = finche' non passa fireRate tempo, la condizione e' falsa.
