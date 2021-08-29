using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingData
{

    private string buildingCode;
    private int healthPoints;

    public BuildingData(string _code, int _healthPoints)
    {
        buildingCode = _code;
        healthPoints = _healthPoints;
    }

    public string Code { get => buildingCode; }
    public int HP { get => healthPoints; }
}
