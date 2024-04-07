using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSlot : MonoBehaviour
{
    [SerializeField] private Text _txtNom;
    [SerializeField] private Button _btAtk;

    private AttackData _data;

    private DatabaseManager _databaseMgr;

    private void Awake()
    {
        _databaseMgr = FindObjectOfType<DatabaseManager>();
    }

    public void Init(string name)
    {
        _data = _databaseMgr.GetAttackData(name);

        _txtNom.text = _data.name;
    }
}
