using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] public bool _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _radious = 0.5f;

    private void Update()
    {
        _groundCheck = GroundChecker();
    }
    private bool GroundChecker()
    {
        return Physics.CheckSphere(transform.position, _radious, _groundMask);
    }
}
