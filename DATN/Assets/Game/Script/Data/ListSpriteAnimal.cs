using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimalParameter
{
    public string name;
    public Sprite avatar;
    public AnimalParameter()
    { }
    public AnimalParameter(string name, Sprite avatar)
    {
        this.name = name;
        this.avatar = avatar;
    }
}

[CreateAssetMenu(menuName = "AnimalParameter/Sprite")]
[System.Serializable]
public class AvatarDatabase : ScriptableObject
{
    public List<List<AnimalParameter>> avatarList;
    public AnimalParameter GetAnimalByIdAndDice(int id, int dice)
    {
        AnimalParameter avatar = new AnimalParameter();
        if (dice > avatarList.Count)
        {
            if (id < avatarList[dice - 1].Count)
            {
                avatar = avatarList[dice - 1][id];
            }
            else
            {
                avatar = avatarList[dice - 1][0];
            }
        }
        else
        {
            avatar = avatarList[0][0];
        }
        return avatar;
    }
}