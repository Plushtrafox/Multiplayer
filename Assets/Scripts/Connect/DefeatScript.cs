using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatScript : MonoBehaviourPunCallbacks
{

    public void RegresarLobby()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(2);
    }
}
