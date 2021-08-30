using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxColliderCheck : MonoBehaviour
{
    public bool isBuildable = true;
    [SerializeField]
    private int collisionHit = 0;

    private void Update()
    {
        if (collisionHit > 0)
        {
            isBuildable = false;
        }
        else
        {
            isBuildable = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Terrain") collisionHit++;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Terrain") collisionHit--;
    }



}
