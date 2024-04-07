using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Database/Attack", order = 0)]
public class AttackDatabase : ScriptableObject
{
    public List<AttackData> data = new();
}