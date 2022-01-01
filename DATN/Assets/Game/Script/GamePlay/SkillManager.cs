using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    ListSkill listSkill;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        listSkill = new ListSkill();
    }

    public void CastSkill(TimeSkill timeSkill)
    {
        Skill skill = new Skill();
        List<AnimalTeamPrefab> animalsMyTeam = BattleWindow.Instance.animalTeamPrefabs;
        List<AnimalTeamPrefab> animalEnemyTeam = BattleWindow.Instance.animalEnemyPrefabs;
        foreach (AnimalTeamPrefab myAnimal in animalsMyTeam)
        {
            skill = listSkill.getSkillById(myAnimal.animal.idSkill);
            if((TimeSkill)skill.timeSkill == timeSkill)
            {
                int randomTarget = -1 ;
                switch(skill.idSkill)
                {
                    case 0:
                        randomTarget = Random.Range(0, animalEnemyTeam.Count - 1);
                        animalEnemyTeam[randomTarget].animal.SubHealth(skill.GetValueSkill());
                        break;
                    case 1:
                        randomTarget = Random.Range(0, animalsMyTeam.Count - 1);
                        animalsMyTeam[randomTarget].animal.AddHealth(skill.GetValueSkill());
                        break;
                    case 2:
                        randomTarget = Random.Range(0, animalsMyTeam.Count - 1);
                        animalsMyTeam[randomTarget].animal.AddAttack(skill.GetValueSkill());
                        break;
                    case 3:
                        randomTarget = Random.Range(0, animalsMyTeam.Count - 1);
                        animalsMyTeam[randomTarget].animal.AddAttack(skill.GetValueSkill());
                        animalsMyTeam[randomTarget].animal.AddHealth(skill.GetValueSkill());
                        break;
                    case 4:
                        foreach(AnimalTeamPrefab animal in animalEnemyTeam)
                        {
                            animal.animal.SubHealth(skill.GetValueSkill());
                        }
                        break;
                    case 5:
                        foreach (AnimalTeamPrefab animal in animalEnemyTeam)
                        {
                            animal.animal.SubHealth(skill.GetValueSkill());
                        }
                        break;
                    case 6:
                        myAnimal.animal.AddAttack(skill.GetValueSkill());
                        break;
                    case 7:
                        myAnimal.animal.AddHealth(skill.GetValueSkill());
                        break;
                    case 8:
                        foreach (AnimalTeamPrefab animal in animalEnemyTeam)
                        {
                            animal.animal.SubHealth(skill.GetValueSkill());
                        }
                        foreach (AnimalTeamPrefab animal in animalsMyTeam)
                        {
                            animal.animal.SubHealth(skill.GetValueSkill());
                        }
                        break;
                    case 9:
                        break;

                    case 10:
                        break;
                    case 11:
                        break;

                    case 12:
                        break;
                    case 13:
                        break;

                    case 14:
                        break;
                    case 15:
                        break;

                    case 16:
                        break;
                }
            }
        }
    }

}
