
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class Stats
{

    [SerializeField]
    private int BaseValue;

    //private readonly List<StatModifier> statModifiers;

    public int getValue()
    {
        return BaseValue;
    }
}
