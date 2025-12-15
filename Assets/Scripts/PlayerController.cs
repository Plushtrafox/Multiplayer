using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviourPun
{
    public float speed = 3f;

    
    

    private PlayerInput playerInput;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        // Solo controlamos a nuestro propio jugador
        if (photonView.IsMine)
        {
            // Leemos el valor de la acción "Move" definida en los Input Actions por defecto
            Vector2 inputVector = playerInput.actions["Move"].ReadValue<Vector2>();

            Vector2 move = new Vector2(inputVector.x, inputVector.y) * speed * Time.deltaTime;
            transform.Translate(move);
        }
    }
}