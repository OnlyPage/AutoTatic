using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWindow : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI userName;
    // Start is called before the first frame update
    void Start()
    {
        userName.text = "Welcome  " + PlayerPrefs.GetString(DataPlayerprefer.USERNAME);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_Logout()
    {
        SceneManager.LoadScene(Scenes.LOGIN_SCENE, LoadSceneMode.Single);
    }    
}
