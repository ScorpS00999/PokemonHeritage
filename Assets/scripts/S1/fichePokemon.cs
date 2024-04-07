using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class fichePokemon : MonoBehaviour
{
    public TextMeshProUGUI affichage_vie;
    public TextMeshProUGUI affichage_nom;

    public TextMeshProUGUI affichage_degatsSubie;
    public TextMeshProUGUI affichage_degatsBase;

    public Sprite mon_sprite;
    public Image mon_image;

    private bool CanDamage = true;


    public string nom;
    public int vieBase;
    private int vieActuelle;
    public int attaque;
    public int defense;
    private int pntsStat;
    public float poids;
    public enum types
    {
        Acier, Combat, Dragon, Eau, Fée, Feu, Glace, Insecte, Normal, Plante, Poison, Psy, Roche, Sol, Vol
    }
    private types[] allTypes = { types.Acier, types.Combat, types.Dragon, types.Eau, types.Fée, types.Feu, types.Glace, types.Insecte, types.Normal, types.Plante, types.Poison, types.Psy, types.Roche, types.Sol, types.Vol };

    public types[] faiblesses = { types.Fée, types.Glace };
    public types[] resistances = { types.Plante, types.Sol };

    public types typePokemon;


    void Awake()
    {
        InitCurrentLife();
        InitStatsPoints();
    }

    void Start()
    {
        DisplayName();
        DisplayVie();
        DisplatAttack();
        DisplayDefense();
        DisplayStats();
        DisplayPoids();
        DisplayResistances();
        DisplayFaiblesses();

        mettre_image();
    }

    void FixedUpdate()
    {
        if (CanDamage && vieActuelle > 0)
        {
            StartCoroutine(infliger_degats());
        }
        CheckIfPokemonAlive();
    }

    IEnumerator infliger_degats()
    {
        TakeDamage(Random.Range(1, 6));
        typePokemon = allTypes[Random.Range(0, allTypes.Length - 1)];
        CanDamage = false;
        yield return new WaitForSeconds(1.5f);
        CanDamage = true;
    }

    void mettre_image()
    {
        mon_image.GetComponent<Image>();
        mon_image.sprite = mon_sprite;
    }

    void DisplayName()
    {
        Debug.Log(nom);
        affichage_nom.text = nom.ToString();
    }

    void DisplayVie()
    {
        Debug.Log(vieActuelle);
        affichage_vie.text = vieActuelle.ToString()+" /100";
    }

    void DisplatAttack()
    {
        Debug.Log(attaque);
    }

    void DisplayDefense()
    {
        Debug.Log(defense);
    }

    void DisplayStats()
    {
        Debug.Log(pntsStat);
    }

    void DisplayPoids()
    {
        Debug.Log(poids);
    }

    void DisplayResistances()
    {
        Debug.Log(resistances);
    }

    void DisplayFaiblesses()
    {
        Debug.Log(faiblesses);
    }



    void InitCurrentLife()
    {
        vieActuelle = vieBase;
    }

    void InitStatsPoints()
    {
        pntsStat = vieActuelle + attaque + defense;
    }

    int GetAttackDamage()
    {
        return attaque;
    }



    bool VerifFaiblesse()
    {
        foreach (types faiblesse in faiblesses)
        {
            if (faiblesse == typePokemon)
            {
                return true;
            }
        }
        return false;
    }

    bool VerifResistance()
    {
        foreach (types resistance in resistances)
        {
            if (resistance == typePokemon)
            {
                return true;
            }
        }
        return false;
    }



    void TakeDamage(int degats)
    {
        int degatsSubie = degats;

        if (!(degats <= 0))
        {
            if (VerifFaiblesse())
            {
                degatsSubie = degats * 2;
            }
            else if (VerifResistance())
            {
                degatsSubie = degats / 2;
            }
        }

        if (degatsSubie > vieActuelle)
        {
            degatsSubie = vieActuelle;
        }

        affichage_degatsBase.text = "Degats infliger : " + degats.ToString();
        affichage_degatsSubie.text = "Degats subie : " + degatsSubie.ToString();

        vieActuelle -= degatsSubie;

        DisplayVie();
    }

    void CheckIfPokemonAlive()
    {
        if (vieActuelle <= 0)
        {
            Debug.Log("Le pokemon est mort");
        }
        else
        {
            Debug.Log("le pokemon à " +  vieActuelle);
            DisplayVie();
        }
    }

}