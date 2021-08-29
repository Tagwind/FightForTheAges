using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{

    private Building placedBuilding = null;
    private float previousX;
    private float previousZ;
    private Building building;
    

    // Start is called before the first frame update
    void Start()
    {
        PreparePlacement(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PreparePlacement(0);
        }

        FollowMouse();
    }


    //Once building is instantiated follow the mouse around until place in valid location.
    private void FollowMouse()
    {
        if(placedBuilding != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                Destroy(placedBuilding.Transform.gameObject);
                building = null;
            }

            if(building != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;              

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, Globals.terrainMask))
                {
                    if (previousX != hit.point.x || previousZ != hit.point.z )
                    {
                        previousX = hit.point.x;
                        previousZ = hit.point.z;

                        building.Transform.position = new Vector3(hit.point.x, 0f, hit.point.z);
                    }

                    if (Input.GetMouseButtonDown(0) && CanBuild())
                    {
                        building = null;
                    }

                }
            }
        }
    }

    private bool CanBuild()
    {

        if (building.Transform.GetComponentInChildren<BoxColliderCheck>().CanBuild)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //TO DO: Temp function to instatiate a building. Flesh out or delete.
    private void PreparePlacement(int dataIndex)
    {


        //Creates the building object!
        building = new Building(Globals.BUILDING_DATA[dataIndex]);

        placedBuilding = building;

    }


}
