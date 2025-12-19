using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviourPun
{
    public float speed = 3f;
    [SerializeField] private Vector2 inputVector;

    private PlayerInput playerInput;

    private Rigidbody2D rb;
    [SerializeField] private float SaltoFuerza = 5f;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Color colorJugador;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        playerInput = GetComponent<PlayerInput>();

        playerInput.actions["Caminar"].performed+=Mover;
        playerInput.actions["Caminar"].canceled += Mover;

        playerInput.actions["Saltar"].started += Saltar;

        playerInput.actions["Atacar"].started += Atacar;

        if (photonView.IsMine == false) 
        {
            print("No es mi jugador, se desactivara");
            playerInput.enabled = false;
            

        }
        if(photonView.IsMine == true)
        {
            sprite.color = colorJugador;
        }





    }

    private void Atacar(InputAction.CallbackContext contexto)
    {

        
            print("Atacando");
        

    }

    private void Saltar(InputAction.CallbackContext contexto)
    {
        if (photonView.IsMine)
        {
            rb.AddForce(Vector2.up * SaltoFuerza, ForceMode2D.Impulse);
        }
    }
    private void Mover(InputAction.CallbackContext contexto)
    {
        inputVector = contexto.ReadValue<Vector2>();
        if (inputVector.x < 0)
        {
            sprite.flipX = true;
        }
        else if (inputVector.x > 0)
        {
            sprite.flipX = false;
        }

    }

    void Update()
    {
        // Solo controlamos a nuestro propio jugador
        if (photonView.IsMine)
        {
   
                
           
            // Leemos el valor de la acción "Move" definida en los Input Actions por defecto
            rb.linearVelocity = new Vector2(inputVector.x * speed, inputVector.y * speed);

        }
    }

    private void OnDisable()
    {
        playerInput.actions["Caminar"].performed -= Mover;
        playerInput.actions["Caminar"].canceled -= Mover;
        playerInput.actions["Saltar"].started -= Saltar;

    }
}