using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimalPrefab : MonoBehaviour , IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private Image animalImage;
    [SerializeField]
    private Image animalTier;
    [SerializeField]
    private RectTransform animalTransform;

    private float posX;
    private float posY;
    private bool onDrag;

    private bool onTrigger;
    private Collider2D animalTeam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAnimal(Sprite animal, Sprite tierDice)
    {
        this.gameObject.SetActive(true);
        animalImage.sprite = animal;
        animalTier.sprite = tierDice;
    }

    public void OnDrag(PointerEventData eventData)
    {
        onDrag = true;
        animalTransform.anchoredPosition += eventData.delta;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        posX = animalTransform.anchoredPosition.x;
        posY = animalTransform.anchoredPosition.y;
        GameWindow.instance.ShowAllBgChoose();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameWindow.instance.hideAllBgChoose();
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        Debug.Log("Up");
        bool isSuccess;
        if(onTrigger)
        {
            isSuccess = GameWindow.instance.SubGold(2);
            if (isSuccess)
            {
                animalTeam.gameObject.GetComponent<AnimalTeamPrefab>().setAnimalImage(animalImage.sprite, animalTier.sprite);
                ClearAnimal();
            }
        }
        animalTransform.anchoredPosition = new Vector2(posX, posY);
        GameWindow.instance.hideAllBgChoose();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(gameObject.name);
        animalTeam = collision;
        if (!onTrigger)
            GameWindow.instance.ShowBgChooseById(animalTeam.gameObject.GetComponent<AnimalTeamPrefab>().getIdAnimalTeam());
        onTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("end " +gameObject.name);
        if (onTrigger)
            GameWindow.instance.ShowAllBgChoose();
        onTrigger = false;
    }

    private void ClearAnimal()
    {
        gameObject.SetActive(false);
    }    
}
