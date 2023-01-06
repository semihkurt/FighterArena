using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : Manager<GameManager>
{
    public EntitiesDatabaseSO entitiesDatabase;

    [SerializeField]
    public GameObject textObject;

    public Transform team1Parent;
    public Transform team2Parent;

    public Action OnRoundStart;
    public Action<Team> OnRoundEnd;
    public Action<BaseEntity> OnUnitDied;

    List<BaseEntity> team1Entities = new List<BaseEntity>();
    List<BaseEntity> team2Entities = new List<BaseEntity>();

    public int unitsPerTeam = 2;

    public void OnEntityBought(EntitiesDatabaseSO.EntityData entityData)
    {
        BaseEntity newEntity = Instantiate(entityData.prefab, team1Parent);
        newEntity.gameObject.name = entityData.name;
        team1Entities.Add(newEntity);

        newEntity.Setup(Team.Team1, GridManager.Instance.GetFreeNode(Team.Team1));
    }

    public List<BaseEntity> GetEntitiesAgainst(Team against)
    {
        if (against == Team.Team1)
            return team2Entities;
        else
            return team1Entities;
    }

    public void UnitDead(BaseEntity entity)
    {
        team1Entities.Remove(entity);
        team2Entities.Remove(entity);

        OnUnitDied?.Invoke(entity);

        if(team1Entities.Count == 0)
        {
            Debug.Log("Team 1 lost!!");
            if(textObject)
                textObject.GetComponent<TMP_Text>().text = "Team 2 Wins! You lost the round!";
            OnRoundEnd?.Invoke(Team.Team2);

            
        }else if(team2Entities.Count == 0)
        {
            if(textObject)
               textObject.GetComponent<TMP_Text>().text = "Team 1 Wins! You win the round!";
            Debug.Log("Team 2 lost!!");
            OnRoundEnd?.Invoke(Team.Team1);
        }

        Destroy(entity.gameObject);
    }


    public void DebugFight()
    {
        for (int i = 0; i < unitsPerTeam; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, entitiesDatabase.allEntities.Count);
            BaseEntity newEntity = Instantiate(entitiesDatabase.allEntities[randomIndex].prefab, team2Parent);

            team2Entities.Add(newEntity);

            newEntity.Setup(Team.Team2, GridManager.Instance.GetFreeNode(Team.Team2));
        }
    }

    public void Return()
    {
        SceneManager.LoadScene(1);
    }

    private void Start() {
        if(LevelManager.instance.lvl1Finished == false)
        {
            unitsPerTeam = 2;
        }else if(LevelManager.instance.lvl2Finished == false)
        {
            unitsPerTeam = 3;
        }else if(LevelManager.instance.lvl3Finished == false)
        {
            unitsPerTeam = 4;
        }else if(LevelManager.instance.lvl4Finished == false)
        {
            unitsPerTeam = 5;
        }

        /*for (int i = 0; i < unitsPerTeam; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, entitiesDatabase.allEntities.Count);
            BaseEntity newEntity = Instantiate(entitiesDatabase.allEntities[randomIndex].prefab, team2Parent);

            team2Entities.Add(newEntity);

            newEntity.Setup(Team.Team2, GridManager.Instance.GetFreeNode(Team.Team2));
        }*/
    }
}

public enum Team
{
    Team1,
    Team2
}
