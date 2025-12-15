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
        StartCoroutine(PingLoop());

    }
    private IEnumerator PingLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            if (PhotonNetwork.IsConnected)
            {
                int ping = PhotonNetwork.GetPing();
                Debug.Log("Ping: " + PhotonNetwork.GetPing() + " ms");
            }
        }
    }


}
