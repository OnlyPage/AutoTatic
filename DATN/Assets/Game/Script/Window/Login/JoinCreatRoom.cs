using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JoinCreatRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMPro.TMP_InputField input;

    [SerializeField]
    private GameObject createAndJoinObj;
    [SerializeField]
    private GameObject roomObj;

    [SerializeField]
    private TMPro.TextMeshProUGUI roomNameText;

    private string nameRoom;
    private bool isCreate;

    // Start is called before the first frame update
    void Start()
    {
        isCreate = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string randomString(int length)
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var stringChars = new StringBuilder();
        for (var i = 0; i < length; i++)
        {
            var c = chars[UnityEngine.Random.Range(0, chars.Length)];
            stringChars.Append(c);
        }

        return stringChars.ToString();
    }

    public void Onclick_Create()
    {
        nameRoom = randomString(5);
        PhotonNetwork.CreateRoom(nameRoom);
        isCreate = true;
    }

    public void Onclick_Join()
    {
        PhotonNetwork.JoinRoom(input.text);
        isCreate = false;
    }

    public override void OnCreatedRoom()
    {
        createAndJoinObj.SetActive(false);
        roomObj.SetActive(true);
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnJoinedRoom()
    {
        createAndJoinObj.SetActive(false);
        roomObj.SetActive(true);
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
    }

    public void Onclick_StartGame()
    {
        SceneManager.LoadScene(Scenes.GAME_SCENE);
    }
}


