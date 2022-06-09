using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenSystem : MonoBehaviour
{
    [SerializeField]
    public float i_PlayerOxygen = 100;

    void Start()
    {
        InvokeRepeating("Subtract", 1f, 1f);
    }

    void Subtract()
    {
        i_PlayerOxygen -= .5f;
    }
}
