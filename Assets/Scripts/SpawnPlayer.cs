using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviourPunCallbacks
{

    [SerializeField] private PhotonView playerPrefab;
    [SerializeField] private Transform posicionSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, posicionSpawn.position, posicionSpawn.rotation);
 

    }

}
