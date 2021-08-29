using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
    private BuildingData data;
    private Transform transform;
    private int currentHealth;
    private bool isBuildable;
    private int collisionHit;

    public Building(BuildingData _data)
    {
        data = _data;
        currentHealth = _data.HP;

        GameObject g = GameObject.Instantiate(Resources.Load($"Prefabs/Buildings/{data.Code}")) as GameObject;

        transform = g.transform;
        isBuildable = true;
        collisionHit = 0;

    }

    public string Code { get => data.Code; }
    public Transform Transform { get => transform; }
    public int HP { get => currentHealth; set => currentHealth = value; }
    public int MaxHP { get => data.HP; }
    public bool Buildable { get => isBuildable; set => isBuildable = value; }
    public int Hits { get => collisionHit; set => collisionHit = value; }

    public int DataIndex
    {
        get
        {
            for(int i = 0; i <Globals.BUILDING_DATA.Length; i++)
            {
                if(Globals.BUILDING_DATA[i].Code == data.Code)
                {
                    return i;
                }
            }
            return -1;
        }
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    

}
