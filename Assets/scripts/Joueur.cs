using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    public string nom;
    public int ID;
    public int ip;

    public static int nbConnectedPlayers = 0;

    public Joueur() 
    {
        nbConnectedPlayers ++;
    }


}
