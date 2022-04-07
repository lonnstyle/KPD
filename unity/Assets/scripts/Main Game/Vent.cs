using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    public int ID = 0;
    public VentsSystem ventsSystem;

    public Vector3 GetPos()
    {
        return this.transform.position;
    }

    #region Triggers

    public void EnableVent(PlayerMovement PlayerMovement)
    {
        ventsSystem.CanEnterVentSystem(PlayerMovement, ID);
    }
    public void DisableVent()
    {
        ventsSystem.CantEnterVentSystem();
    }
    #endregion 
}