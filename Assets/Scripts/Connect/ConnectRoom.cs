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
    void Awake()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;


    }

    public void CrearSala()
    {
               PhotonNetwork.CreateRoom(nombreSalaCrear.text);

    }
    public void UnirseSala(string sala)
    {
        PhotonNetwork.JoinRoom(sala);
    }

    public override void OnCreatedRoom()
    {
        print("se creo una sala");
        
    }
    public override void OnJoinedRoom()
    {
        print("se unio a una sala");
        PhotonNetwork.LoadLevel(3);
    }

    public override void OnLeftRoom()
    {
     
        print("dejamos una sala");
    }
    public override void OnJoinedLobby()
    {
        print("estamos en el lobby");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform child in salaBotonParent)
        {
            Destroy(child.gameObject);
        }
        for (int i=0;i<roomList.Count; i++)
        {
            GameObject salaBotonNuevo=Instantiate(salaBotonPrefab,salaBotonParent,false);
            Button botonSala=salaBotonNuevo.GetComponent<Button>();

            string nombreSala = roomList[i].Name;
            botonSala.onClick.AddListener(() => UnirseSala(nombreSala));
       
            TextMeshProUGUI textoBoton= salaBotonNuevo.GetComponentInChildren<TextMeshProUGUI>();
            textoBoton.text = roomList[i].Name;


        }
    }


}
