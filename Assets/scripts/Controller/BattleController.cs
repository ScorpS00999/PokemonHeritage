using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public PokemonController pokemon;
    public PokemonController pokemonCPU;



    private DatabaseManager _databaseMgr;

    private void Awake()
    {
        _databaseMgr = FindObjectOfType<DatabaseManager>();
    }


    void Start()
    {
        pokemon.Init(_databaseMgr.GetData(0));
        pokemonCPU.Init(_databaseMgr.GetData(4));
    }

    void Update()
    {
        
    }
}
