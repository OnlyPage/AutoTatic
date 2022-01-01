using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWindow : MonoBehaviour
{
    public static BattleWindow Instance;

    [SerializeField]
    public List<AnimalTeamPrefab> animalTeamPrefabs;
    [SerializeField]
    public List<AnimalTeamPrefab> animalEnemyPrefabs;

    public List<AnimalTeamPrefab> animalTeam;
    public List<AnimalTeamPrefab> animalEnemy;

    // Start is called before the first frame update
    void Start()
    {
        animalTeamPrefabs.Clear();
        animalEnemyPrefabs.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddAnimalTeam(List<AnimalTeamPrefab> animalTeams)
    {
        for(int i =0; i< animalTeams.Count; i++)
        {
            animalTeamPrefabs[i].animal = animalTeam[i].animal;
        }

    }

    public void AddEnemyTeam(List<AnimalTeamPrefab> animalEnemy)
    {
        this.animalEnemy = animalEnemy;
    }

}
