using Photon.Pun;
using UnityEngine;

public class DisparoScript : MonoBehaviour
{
    private PhotonView idPlayerDisparador;
    public PhotonView IdPlayerDisparador
    {
        get { return idPlayerDisparador; }
        set { idPlayerDisparador = value; }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PhotonView enemigoPV=collision.GetComponent<PhotonView>();
            if (idPlayerDisparador.ViewID!=enemigoPV.ViewID)
            {
                // HACER DAÑO AL ENEMIGO
                IdPlayerDisparador.RPC("Perder", RpcTarget.Others);

                //mandar EVENTO PARA TERMINAR JUEGO
            }
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
