using UnityEngine;

public class DisparoScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            // HACER DAÑO AL ENEMIGO

            //disparar evento daño enemigo





            //Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
    }
}
