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

    public void EnableVent(CharacterController2D characterController2D)
    {
        ventsSystem.CanEnterVentSystem(characterController2D, ID);
    }
    public void DisableVent()
    {
        ventsSystem.CantEnterVentSystem();
    }
    #endregion 
}