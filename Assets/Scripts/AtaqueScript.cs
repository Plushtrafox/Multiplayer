using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class AtaqueScript : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private GameObject prefabAtaque;

    [SerializeField] private Transform spawnDisparo;

    [SerializeField] private float tiempoEntreAtaques = 0.5f;

    private bool _puedeAtacar = true;

    [SerializeField] private float velocidadAtaque=10f;

    private void Awake()
    {
        playerInput.actions["Atacar"].started += DispararAtaque;
    }

    private void DispararAtaque( InputAction.CallbackContext contexto)
    {
        if (_puedeAtacar)
        {
            GameObject disparoNuevo = Instantiate(prefabAtaque, spawnDisparo.position, spawnDisparo.rotation);
            Rigidbody2D rbNuevo = disparoNuevo.GetComponent<Rigidbody2D>();
            if (transform.localScale.x > 0)
            {

                rbNuevo.AddForce(spawnDisparo.right * velocidadAtaque, ForceMode2D.Impulse);
            }
            else if (transform.localScale.x < 0)
            {
                rbNuevo.AddForce(spawnDisparo.right * -velocidadAtaque, ForceMode2D.Impulse);
            }
            _puedeAtacar = false;
            StartCoroutine(ReactivarAtaque());

        }



    }

    IEnumerator ReactivarAtaque()
    {
        yield return new WaitForSeconds(tiempoEntreAtaques);
        _puedeAtacar = true;
    }

    private void OnDisable()
    {
        playerInput.actions["Atacar"].started -= DispararAtaque;
    }

}
