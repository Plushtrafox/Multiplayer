using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviourPunCallbacks
{

    public void RegresarLobby()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(2);
    }
}
