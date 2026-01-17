using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Camera settings")]
    [SerializeField] private float _sensitivity = 100; // Quanto amplificare il movimento mouse/cam

    private float _rotationX = 0; // Rotazione nel tempo

    private void Update()
    {
        CameraControlRules();
    }

    void CameraControlRules()
    {
        float mouseX = Input.GetAxis("Mouse X") * (_sensitivity * Time.deltaTime); // Quanto il mouse si e' mosso in ORIZZONTALE (+ DX, - SX)
        float mouseY = Input.GetAxis("Mouse Y") * (_sensitivity * Time.deltaTime); // Quanto il mouse si e' mosso in VERTICALE (+ UP, - DOWN)
        // * Time.deltaTime per rendere indipendente il movimento dal framerate

        // Controllo angolo di rotazione asse X (Pitch)
        _rotationX -= mouseY; // Per guardare su con mouse in alto (_rotationX diminuisce)
        _rotationX = Mathf.Clamp(_rotationX, -80, 80); // Blocco l'angolo di rotazione tra -80 gradi e 80 gradi

        // Rotazione LOCALE, cosi facendo guardo su/giu ma non ruoto il corpo
        transform.localRotation = Quaternion.Euler(_rotationX, 0, 0); // Ruoto oggetto agganciato (Child + Cam) su asse X di _rotationX gradi

        transform.parent.Rotate(Vector3.up, mouseX); // Ruoto il parent a cui ho agganciato il mio check (Player) 
        // Vector3.up per asse Y quindi ruoto attorno (+ mouseX DX/ - mouseY SX)
    }
}
