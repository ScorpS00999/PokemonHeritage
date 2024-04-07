using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class BaseData
{
    public string name;
    public int id;
    [TextArea] public string description;

    public BaseData(string name, int id, string description)
    {
        this.name = name;
        this.id = id;
        this.description = description;
    }
}


[Serializable]
public class PokeData : BaseData
{
    [Serializable]
    public struct Infos
    {
        public int vieActuelle;
        public float pntStats;
    }

    public float height;
    public float weight;
    public Sprite icon;

    public Infos info;
    public Stats stats;
    public ApiType[] apiTypes;

    [Serializable]
    public struct AttackWrapper
    {
        public string name;
        public int level;

        public AttackWrapper(string name, int level)
        {
            this.name = name;
            this.level = level;
        }
    }
    public List<AttackWrapper> attack;


    public PokeData(string name, int id, string description, float height, float weight, Sprite icon) : base(name, id, description)
    {
        this.height = height;
        this.weight = weight;
        this.icon = icon;
    }

    public void InitCurrentLife()
    {
        this.info.vieActuelle = this.stats.HP;
    }

    public void InitStatsPoints()
    {
        this.info.pntStats = this.info.vieActuelle + this.stats.attack + this.stats.defense;
    }

    public bool IsPokemonAlive() { return this.info.vieActuelle > 0; }
}


[Serializable]
public class Stats
{
    public int HP;
    public int attack;
    public int defense;
    public int special_attack;
    public int special_defense;
    public int speed;

    public Stats() { }


    public Stats(int hP, int attack, int defense, int special_attack, int special_defense, int speed)
    {
        HP = hP;
        this.attack = attack;
        this.defense = defense;
        this.special_attack = special_attack;
        this.special_defense = special_defense;
        this.speed = speed;
    }
}

[Serializable]
public class ApiType
{
    public string name;
    public string image;
    public Sprite icon;

    public ApiType(string name, Sprite icon)
    {
        this.name = name;
        this.icon = icon;
    }
}




[Serializable]
public class AttackData : BaseData
{
    public int damage;
    public CLASSES classes;
    public TYPES types;

    public AttackData(string name, int id, string description) : base(name, id, description) { }


    public enum CLASSES
    {
        physique,
        spéciale,
        statue
    }

    //Trouver comment faire avec l'api
    public enum TYPES
    {
        Normal,
        Combat,
        Vol,
        Poison,
        Sol,
        Roche,
        Insecte,
        Spectre,
        Acier,
        Feu,
        Eau,
        Plante,
        Électrik,
        Psy,
        Glace,
        Dragon,
        Ténèbres,
        Fée
    }
}