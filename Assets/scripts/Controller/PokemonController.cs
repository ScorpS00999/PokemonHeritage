using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonController : MonoBehaviour
{
    [SerializeField] private Text _txtNom;
    [SerializeField] private Image _imgIcon;

    [Header("PV")]
    [SerializeField] private Image _imgPv;
    [SerializeField] private Text _textPv;

    private PokeData _data;
    private int _currentLife;

    [SerializeField] private List<AttackSlot> _atkSlot = new();


    public void Init(PokeData data)
    {
        _data = data;
        _txtNom.text = _data.name;
        _imgIcon.sprite = _data.icon;

        _currentLife = _data.stats.HP;


        foreach (AttackSlot slot in _atkSlot)
        {
            var id = _atkSlot.IndexOf(slot);
            slot.Init(data.attack[id].name);
        }

        RefreshUI();
    }

    public void RefreshUI()
    {
        _textPv.text = $"{_currentLife:00} / {_data.stats.HP:00}";
    }

    private void InitAtk()
    {

    }
}
