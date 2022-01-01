using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum StateGame
{
    Ready,
    StartGame,
    Attack,
    EndGame
}

public class GameManager : MonoBehaviour
{
    private float countStart = 0f ;
    StateGame stateGame;
    // Start is called before the first frame update
    void Start()
    {
        stateGame = StateGame.Ready;
        countStart = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(countStart > 0 && stateGame == StateGame.Ready)
        {
            countStart -= Time.deltaTime;
        }    
        else
        {
            stateGame = StateGame.StartGame;
            SkillManager.instance.CastSkill(TimeSkill.gameStart);
            stateGame = StateGame.Attack;
        }    

        if( stateGame == StateGame.Attack)
        {
            Attack();
        }
    }


    public void Attack()
    {
        AnimalTeamPrefab animalTeam = BattleWindow.Instance.animalEnemyPrefabs[0];
        AnimalTeamPrefab enemyTeam = BattleWindow.Instance.animalEnemyPrefabs[0];

        enemyTeam.animal.SubHealth(animalTeam.animal.attack);
        SkillManager.instance.CastSkill(TimeSkill.attack);
        if(enemyTeam.animal.GetStatus() == Status.die)
        {
            Destroy(BattleWindow.Instance.animalEnemyPrefabs[0].gameObject);
        }
    }    
}
