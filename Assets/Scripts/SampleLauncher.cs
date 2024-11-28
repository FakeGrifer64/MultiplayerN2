using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SampleLauncher : MonoBehaviourPunCallbacks
{

    public PhotonView playerPrefab;

    public TMP_InputField playerNickName;
    public GameObject nickNameInput;


    public string chosenAvatar = "AvatarOne";

    // Start is called before the first frame update
    void Start()
    {
        //PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("joined a room");
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
    }

    public void StartTheGame()
    {
        PhotonNetwork.NickName = playerNickName.text + " | " + chosenAvatar;
        PhotonNetwork.ConnectUsingSettings();

        nickNameInput.SetActive(false);
    }

    public void SetAvatar(string avatarName)
    {
        chosenAvatar = avatarName;
    }
}
