using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Photon.Realtime;


public class ConnectRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI nombreSalaCrear;
    [SerializeField] private GameObject salaBotonPrefab;
    [SerializeField] private Transform salaBotonParent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void CrearSala()
    {
               PhotonNetwork.CreateRoom(nombreSalaCrear.text);

    }
    public void UnirseSala(string sala)
    {
        PhotonNetwork.JoinRoom(sala);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnCreatedRoom()
    {
        PhotonNetwork.JoinRoom(nombreSalaCrear.text);
    }
    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene(3);
    }



    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for(int i=0;i<roomList.Count; i++)
        {
            GameObject salaBotonNuevo=Instantiate(salaBotonPrefab,salaBotonParent,true);
            Button botonSala=salaBotonNuevo.GetComponent<Button>();
            botonSala.onClick.AddListener(delegate { UnirseSala(roomList[i].Name); });
            TextMeshProUGUI textoBoton=salaBotonPrefab.GetComponentInChildren<TextMeshProUGUI>();
            textoBoton.text = roomList[i].Name;


        }
    }
}
