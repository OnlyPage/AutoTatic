using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DiceParameter
{
    public string name;
    public Sprite sprite;
    public DiceParameter()
    { }
    public DiceParameter(string name, Sprite sprite)
    {
        this.name = name;
        this.sprite = sprite;
    }
}

[CreateAssetMenu(menuName = "AnimalParameter/Dice")]
[System.Serializable]
public class DiceDatabase : ScriptableObject
{
    public List<DiceParameter> diceParameters;
    public DiceParameter GetAnimalByDice(int dice)
    {
        DiceParameter diceSprite = new DiceParameter();
        if (dice > diceParameters.Count)
        {
            diceSprite = diceParameters[dice - 1];
        }
        else
        {
            diceSprite = diceParameters[0];
        }
        return diceSprite;
    }
}