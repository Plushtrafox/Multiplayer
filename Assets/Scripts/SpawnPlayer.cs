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

    [SerializeField] private static bool yaCreado=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        int playerID = playerPrefab.ViewID;
        string ownerName = playerPrefab.Owner?.NickName ?? "null";
        bool isMine = playerPrefab.IsMine;
        if (!yaCreado)
        {

            Debug.Log($"<color=cyan> JUGADOR CREADO - {gameObject.name}</color>");
            Debug.Log($"   ViewID: {playerID}");
            Debug.Log($"   Owner: {ownerName}");
            Debug.Log($"   IsMine: {isMine}");

            print("Creando jugador");
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(Random.Range(minx, maxx), Random.Range(miny, maxy)), posicionSpawn.rotation);


            yaCreado = true;
        }


    }

    private void OnDestroy()
    {
        if (PhotonNetwork.InRoom == false)
        {
            Debug.LogError($"<color=red> JUGADOR DESTRUIDO - {gameObject.name}</color>");
            Debug.LogError($"   ViewID: {photonView.ViewID}");
            Debug.LogError($"   Owner: {photonView.Owner?.NickName ?? "null"}");
            Debug.LogError($"   Stack trace:");
            Debug.LogError(System.Environment.StackTrace);
            yaCreado = false;
        }
    }

}
