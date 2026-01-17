using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private float _rotationSpeed = 5;
    [SerializeField] private float _maxJumps = 2;
    [SerializeField] private float _mass = 1.1f;

    private Rigidbody _rb;
    private GroundCheck _gc;
    private Vector3 _inputDirection;
    private bool shift;
    private float _currentJumps = 0;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.mass = _mass;

        _gc = GetComponentInChildren<GroundCheck>(); // Sta come Child del Player quindi questo
    }

    private void Update()
    {
        AxisInput(); // Muovo il player
        JumpingLogic(); // Logica di salto
        //RotationTowards(_inputDirection); <-- La scelta prevale sulla camera in questo momento
    }

    private void FixedUpdate()
    {
        Vector3 move;

        if (shift)
        {
            move = _inputDirection * ((_speed * 2) * Time.fixedDeltaTime);
        }
        else
        {
            move = _inputDirection * (_speed * Time.fixedDeltaTime); // Calcolo di quanto devo muovermi  (direzione * velocita' * tempo)
        }
        _rb.MovePosition(transform.position + move); // Movimento verso la nuova direzione
    }

    private void RotationTowards(Vector3 direction)
    {
        if (direction == Vector3.zero) return;

        // Interpolazione, direzione intermedia tra player, direzione verso la quale ruoto e quanto velocemente ruoto
        Vector3 _smoothDir = Vector3.Lerp(transform.forward, direction, _rotationSpeed * Time.deltaTime);

        // Rotazione 3D
        transform.rotation = Quaternion.LookRotation(_smoothDir);
    }

    private void JumpingLogic()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_gc._groundCheck)
            {
                _currentJumps = 0;
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _currentJumps++;
            }
            else if (_currentJumps < _maxJumps)
            {
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _currentJumps++;
            }
        }
    }

    private void AxisInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        shift = Input.GetKey(KeyCode.LeftShift);

        _inputDirection = new Vector3(h, 0f, v).normalized; // 0f = y perche' non devo muovermi su/giu
        _inputDirection = transform.TransformDirection(_inputDirection); // Converto in direzione globale
    }
}
