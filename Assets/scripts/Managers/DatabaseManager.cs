using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public PokeDatabase database;
    public AttackDatabase attackDatabase;

    public ApiPokemon ApiPoke;

    public PokeData GetData(int id) => database.data[id];

    public int Combien() => database.data.Count;

    public AttackData GetAttackDataId(string id)
    {
        return attackDatabase?.data.Find(x => x.id.ToString() == id);
    }

    
    void Awake()
    {
        //database.InitData();

        Sprite pokeIcon = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/sprite/38.png", typeof(Sprite));

        //StartCoroutine(CompletePokeData());
    }

    public IEnumerator CompletePokeData()
    {
        //database.CreationPoke(0, "Feunard", 11, 199, pokeIcon, new Stats(73, 76, 75, 81, 100, 100));

        StartCoroutine(ApiPoke.AddApiPoke(280));
        yield return new WaitForSeconds(2);
        StartCoroutine(ApiPoke.AddApiPoke(281));
        yield return new WaitForSeconds(2);
        StartCoroutine(ApiPoke.AddApiPoke(282));
        yield return new WaitForSeconds(2);

        for (int i = 1; i < 10; i++)
        {
            StartCoroutine(ApiPoke.AddApiPoke(i));
            yield return new WaitForSeconds(2);
        }
    }


    public AttackData GetAttackData(string nom)
    {
        return attackDatabase?.data.Find(x => x.name.ToLower().Contains(nom.ToLower()));
    }
}
