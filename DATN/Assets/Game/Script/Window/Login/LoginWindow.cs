using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginWindow : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_InputField userName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_Play()
    {
        PlayerPrefs.SetString(DataPlayerprefer.USERNAME, userName.text);
        SceneManager.LoadScene(Scenes.GAME_SCENE, LoadSceneMode.Single);
    }    
}
