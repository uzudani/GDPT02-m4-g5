using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _maxDegrees = 180;
    private Rigidbody _rb;
    private PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        if (player == null)
        {
            return;
        }
        transform.position =  Vector3.MoveTowards(transform.position, player.transform.position, _speed *  Time.deltaTime);

        Vector3 direction = (player.transform.position - _rb.position).normalized; //<- o transform.position

        Quaternion focusRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, focusRotation, _maxDegrees * Time.deltaTime);
    }
    
}
//private void EnemyMovement()
//{
//    if (player)
//    {
//        Vector3 enemyMovement = Vector3.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);
//        transform.position = enemyMovement;
//    }
//}
