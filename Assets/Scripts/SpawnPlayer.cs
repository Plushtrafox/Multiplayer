using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviourPunCallbacks
{

    [SerializeField] private PhotonView playerPrefab;
    [SerializeField] private Transform posicionSpawn;

    [SerializeField] private float minx=-7f;
    [SerializeField] private float maxx=10f;
    [SerializeField] private float miny =1f;
    [SerializeField] private float maxy=4f;

    [SerializeField] private bool spawnLocal=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!spawnLocal)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(Random.Range(minx, maxx), Random.Range(miny, maxy)), posicionSpawn.rotation);
            spawnLocal = true;
        }


    }

}
