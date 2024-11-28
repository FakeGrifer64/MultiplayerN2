using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPlayerNickName : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = photonView.Owner.NickName.Split(" | ")[0];
        Debug.Log(photonView.Owner.NickName.Split(" | "));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
