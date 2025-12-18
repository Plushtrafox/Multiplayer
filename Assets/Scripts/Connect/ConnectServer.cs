using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.Collections;



public class ConnectServer : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene(1);

    }



}
