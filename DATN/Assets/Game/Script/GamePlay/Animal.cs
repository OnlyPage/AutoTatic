using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Level
{
    public int lv;
    public int exp;

    public Level()
    {
        lv = 1;
        exp = 1;
    }

    public bool addExp()
    {
        switch(lv)
        {
            case 1:
                exp++;
                if(exp == 3)
                {
                    exp = 1;
                    lv++;
                }
                return true;
            case 2:
                exp++;
                if (exp == 4)
                {
                    exp = 4;
                    lv++;
                }
                return true;
            default:
                return false;
        }
    }
}

[System.Serializable]
public enum Tool
{
    none,
    armor,
    superAmor,
    stick,
    rock,
    drug
}

[System.Serializable]
public enum Status
{
    attack,
    skill,
    die,
    idle,
    hurt
}

[System.Serializable]
public enum TimeSkill
{
    attack,
    die,
    hurt,
    gameStart,
    eatFood,
    friendDie,
    friendHurt
}

[System.Serializable]
public class Skill
{
    public int idSkill;
    public int idTarget;
    public int value;
    public int timeSkill;
    public int level;

    public int GetValueSkill()
    {
        return value * level;
    }
}    

[System.Serializable]
public class ListSkill 
{
    List<Skill> listSkill;
    // Read json
    public Skill getSkillById(int id)
    {
        Skill data = new Skill();
        foreach(Skill skill in listSkill)
        {
            if(id == skill.idSkill)
            {
                data = skill;
                break;
            }
        }
        return data;
    }
}

public class Animal 
{
    public int idAnimal;
    public int health;
    public int attack;
    public int idSkill;
    private Level level;

    private Tool tool;
    private Status status; 

    public Animal(int idAnimal, int health, int attack, int idSkill)
    {
        this.idAnimal = idAnimal;
        this.health = health;
        this.attack = attack;
        this.idSkill = idSkill;
        status = Status.idle;
        level = new Level();
        tool = Tool.none;
    }    

    public bool AddExpAnimal()
    {
        if (level.addExp())
        {
            health++;
            attack++;
            return true;
        }
        else
            return false;
    }

    public void AddHealth(int value)
    {
        health += value;
        if(health > 40)
        {
            health = 40;
        }
    }

    public void AddAttack(int value)
    {
        attack += value;
        if (attack > 40)
        {
            attack = 40;
        }
    }

    public void AddTool(Tool tool)
    {
        this.tool = tool;
    }    

    public void SubHealth(int value)
    {
        health -= value;
        if(health < 0)
        {
            status = Status.die;
        }    
    }

    public void SubAttack(int value)
    {
        attack -= value;
        if (attack < 0)
        {
            attack = 1;
        }
    }

    public Status GetStatus()
    {
        return status;
    }
}
