using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private float speed; // La velocidad a la que se va a mover el personaje
    public float turnSpeed = 300.0f; // La velocidad de giro
    public float originalSpeed;

    private CharacterController characterController;
    private Animator animatorController;

    Vector3 movimientoPersonaje;
    private float velocidadGravedad = 1f;
    private float gravedadMagnitud = -9.81f;
    private float gravedadMultiplicador = 1f;
    public float fuerzaSalto = 15f;

    private bool controlHabilitado;

    void Start()
    {

        characterController = GetComponent<CharacterController>();
        animatorController = GetComponent<Animator>();
        speed = originalSpeed;
        controlHabilitado = false;
    }

    void Update()
    {
        float horizontal = controlHabilitado ? Input.GetAxis("Horizontal") : 0f;
        float vertical = controlHabilitado ? Input.GetAxis("Vertical") : 0f;

        // Controlando si intenta correr
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = originalSpeed + 4f;
        }
        else
        {
            speed = originalSpeed;

        }
        // Rotamos en el eje Y
        transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);

        // Nos movemos usando el characterController
        movimientoPersonaje = transform.forward * vertical;
        aplicarGravedad();
        comprobarSalto();
        characterController.Move(movimientoPersonaje * speed * Time.deltaTime);


        // TODO: Establecer las transiciones.
        //animatorController.SetFloat("Velocidad", move.z);
        //animatorController.SetFloat("Velocidad", vertical);
        animatorController.SetFloat("Velocidad", characterController.velocity.magnitude *
            (Input.GetKey(KeyCode.S) ? -1 : 1));

        
    }

    private void aplicarGravedad()
    {
        if (characterController.isGrounded)
        {
            velocidadGravedad = -1f;
        }
        else
        {
            velocidadGravedad += gravedadMagnitud * gravedadMultiplicador * Time.deltaTime;
        }
        movimientoPersonaje.y = velocidadGravedad;
        //characterController.Move(new Vector3(0f, velocidadGravedad, 0f));
    }

    private void comprobarSalto()
    {
        if (characterController.isGrounded && Input.GetKey(KeyCode.Space) && controlHabilitado)
        {
            velocidadGravedad = fuerzaSalto;
            movimientoPersonaje.y = velocidadGravedad;
        }
    }

    public void setMovimiento(bool habilitarMov)
    {
        controlHabilitado = habilitarMov;
    }
}