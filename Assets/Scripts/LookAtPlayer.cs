using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform t_target;

    private void Update()
    {
        transform.LookAt(t_target);
    }
}
