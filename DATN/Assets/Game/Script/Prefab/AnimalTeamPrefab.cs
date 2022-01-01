using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalTeamPrefab : MonoBehaviour
{
    [SerializeField]
    private GameObject animalPrefab;
    [SerializeField]
    private int idAnimalTeam;

    [SerializeField]
    private Image animalImage;
    [SerializeField]
    private Image tierDice;

    public Animal animal;

    private bool isTriger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setActiveAnimalPrefab(bool value)
    {
        animalPrefab.SetActive(value);
    }

    public void setAnimalImage(Sprite animalSprite,Sprite tierDiceSprite)
    {
        animalImage.sprite = animalSprite;
        tierDice.sprite = tierDiceSprite;
        animalPrefab.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTriger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriger = false;
    }

    public int getIdAnimalTeam()
    {
        return idAnimalTeam;
    }    
}
