using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWindow : MonoBehaviour
{

    public static GameWindow instance;

    [SerializeField]
    private TMPro.TextMeshProUGUI userName;
    [SerializeField]
    public List<Sprite> tier1Icon;
    [SerializeField]
    public List<Sprite> tier2Icon;
    [SerializeField]
    public List<Sprite> tier3Icon;
    [SerializeField]
    public List<Sprite> tierDice;

    [SerializeField]
    private List<GameObject> animalShopPrefab;
    [SerializeField]
    private List<AnimalTeamPrefab> animalTeamPrefab;

    [SerializeField]
    private List<GameObject> listChooseAnimal;

    private List<Image> chooseColor;

    [SerializeField]
    private TMPro.TextMeshProUGUI goldText;

    [SerializeField]
    private TMPro.TextMeshProUGUI timeText;

    private int gold;

    private int randomNumber;
    private int randomAnimal;

    private float countTime;
    // Start is called before the first frame update
    void Start()
    {
        countTime = 20;
        gold = 11;
        instance = this;
        userName.text = "Welcome  " + PlayerPrefs.GetString(DataPlayerprefer.USERNAME);
        chooseColor = new List<Image>();
        foreach (AnimalTeamPrefab animalTeam in animalTeamPrefab)
        {
            animalTeam.setActiveAnimalPrefab(false);
        }


        foreach (GameObject animal in listChooseAnimal)
        {
            chooseColor.Add(animal.GetComponent<Image>());
        }

        PlayerPrefs.SetFloat(DataPlayerprefer.ANIMALSHOP1_x, animalShopPrefab[0].GetComponent<RectTransform>().localPosition.x);
        PlayerPrefs.SetFloat(DataPlayerprefer.ANIMALSHOP1_y, animalShopPrefab[0].GetComponent<RectTransform>().localPosition.y);
        PlayerPrefs.SetFloat(DataPlayerprefer.ANIMALSHOP2_x, animalShopPrefab[1].GetComponent<RectTransform>().localPosition.x);
        PlayerPrefs.SetFloat(DataPlayerprefer.ANIMALSHOP2_x, animalShopPrefab[1].GetComponent<RectTransform>().localPosition.y);
        PlayerPrefs.SetFloat(DataPlayerprefer.ANIMALSHOP3_x, animalShopPrefab[2].GetComponent<RectTransform>().localPosition.x);
        PlayerPrefs.SetFloat(DataPlayerprefer.ANIMALSHOP3_y, animalShopPrefab[2].GetComponent<RectTransform>().localPosition.y);
        OnClick_Roll();       
        hideAllBgChoose();  
    }

    // Update is called once per frame
    void Update()
    {  
        if(countTime > 0)
        {
            countTime -= Time.deltaTime;
            timeText.text = ((int)countTime).ToString();
        }    
        else
        {
            userName.text = "LET'S GO !!";
        }    
    }

    public void OnClick_Logout()
    {
        SceneManager.LoadScene(Scenes.LOGIN_SCENE, LoadSceneMode.Single);
    }

    public void OnClick_Roll()
    {
        if(gold > 0 && countTime > 0)
        {
            gold--;
            goldText.text = gold.ToString();
            foreach (GameObject animal in animalShopPrefab)
            {
                randomNumber = Random.Range(1, 100);
                if (randomNumber < 60)
                {
                    randomAnimal = Random.Range(0, tier1Icon.Count);
                    animal.GetComponent<AnimalPrefab>().ChangeAnimal(tier1Icon[randomAnimal], tierDice[0]);
                }
                else if (randomNumber < 90)
                {
                    randomAnimal = Random.Range(0, tier2Icon.Count);
                    animal.GetComponent<AnimalPrefab>().ChangeAnimal(tier2Icon[randomAnimal], tierDice[1]);
                }
                else
                {
                    randomAnimal = Random.Range(0, tier3Icon.Count);
                    animal.GetComponent<AnimalPrefab>().ChangeAnimal(tier3Icon[randomAnimal], tierDice[2]);
                }

            }
        }       
    }    

    public void ShowAllBgChoose()
    {
        Debug.Log("cz");
        foreach (GameObject gameObject in listChooseAnimal)
        {
            gameObject.SetActive(true);
        }

        foreach (Image color in chooseColor)
        {
            color.color = Color.red;
        }    
    }

    public void hideAllBgChoose()
    {
        Debug.Log("á");
        foreach (GameObject gameObject in listChooseAnimal)
        {
            gameObject.SetActive(false);
        }
    }

    public void ShowBgChooseById(int id)
    {
        id--;
        for (int i = 0; i < listChooseAnimal.Count; i++)
        {
            if(i == id)
            {
                listChooseAnimal[i].SetActive(true);
                chooseColor[i].color = Color.green;
            }    
            else
            {
                listChooseAnimal[i].SetActive(false);
                chooseColor[i].color = Color.red;
            }    
        }    
    }    

    public bool SubGold(int value)
    {
        if (countTime > 0)
        {
            gold -= value;
            if(gold < 0)
            {
                gold += value;
                return false;
            }
            goldText.text = gold.ToString();
            return true;
        }
        else
            return false;
    }
}
