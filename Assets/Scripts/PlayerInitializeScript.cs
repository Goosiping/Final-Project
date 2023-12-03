using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;
using Photon.Realtime;

public class PlayerInitializeScript : MonoBehaviour
{
    private PhotonView _photonView;
    public GameObject virtualCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        if(_photonView != null)
        {

            if(PhotonNetwork.IsConnected && _photonView.IsMine)
            {
                // Virtual Camera Setting
                GameObject playerCamera = Instantiate(virtualCamera, new Vector3(0, 0, 0), Quaternion.identity);
                playerCamera.GetComponent<CinemachineVirtualCamera>().Follow = this.gameObject.transform;
                playerCamera.GetComponent<CinemachineVirtualCamera>().LookAt = this.gameObject.transform;

                GetComponent<movement>().enabled = true;
            }
            
            else if(PhotonNetwork.IsConnected && !_photonView.IsMine)
            {
                GetComponent<movement>().enabled = false;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
