using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Database/Pokemon", order = 0)]
public class PokeDatabase : ScriptableObject
{
    public List<PokeData> data = new();

    public void InitData()
    {
        data.RemoveAll(data => data.id > 0);
        //> 0 et pas >= 0 pour ne pas avoir de problème d'index au lancement 
    }

    
    public void CreationPoke(string nom, string description, int id, int height, float weight, Sprite icon, Stats stats)
    {
        data.Add(new PokeData(nom, id, description, height, weight, icon));
    }
}
