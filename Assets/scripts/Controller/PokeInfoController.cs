using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PokeInfoController : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text nom;
    [SerializeField] private Text taille;
    [SerializeField] private Text poids;

    [SerializeField] private Text hp;
    [SerializeField] private Text attack;
    [SerializeField] private Text def;
    [SerializeField] private Text attack_spe;
    [SerializeField] private Text def_spe;
    [SerializeField] private Text speed;

    [SerializeField] private Text type;
    //[SerializeField] private Image img_type;

    //[SerializeField] private Text description;

    private DatabaseManager _databaseMgr;

    public int compteur_id = 0;

    private void Awake()
    {
        _databaseMgr = FindObjectOfType<DatabaseManager>();
    }

    void Start()
    {
        fichePoke(0);
    }

    public void Add()
    {
        compteur_id++;
        int id_fiche = compteur_id % _databaseMgr.Combien();
        fichePoke(id_fiche);
    }

    public void Remove()
    {
        compteur_id--;
        if (compteur_id < 0)
        {
            compteur_id = _databaseMgr.Combien() + compteur_id;
        }
        int id_fiche = compteur_id % _databaseMgr.Combien();
        fichePoke(id_fiche);
    }

    public void fichePoke(int index)
    {
        PokeData _data = _databaseMgr.GetData(index);

        icon.sprite = _data.icon;
        nom.text = $"Nom : {_data.name}";
        taille.text = $"Taille : {_data.height.ToString()}";
        poids.text = $"Poids : {_data.weight.ToString()}";
        hp.text = $"HP : {_data.stats.HP.ToString()}";
        attack.text = $"Attaque : {_data.stats.attack.ToString()}";
        def.text = $"Défense : {_data.stats.defense.ToString()}";
        attack_spe.text = $"Attaque spécial : {_data.stats.special_attack.ToString()}";
        def_spe.text = $"Défense spécial : {_data.stats.special_defense.ToString()}";
        speed.text = $"Speed : {_data.stats.speed.ToString()}";
        type.text = $"Type : {_data.apiTypes[0].name}";

        //description.text = _data.description;

        //Quelques problèmes avec l'image
        //img_type.sprite = _data.apiTypes[0].img;
    }
}
