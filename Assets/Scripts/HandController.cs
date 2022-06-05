using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class HandController : MonoBehaviour
{
    ActionBasedController abc_Controller;

    public Hand h_Hand;

    void Start()
    {
        abc_Controller = GetComponent<ActionBasedController>(); 
    }

    void Update()
    {
        h_Hand.SetGrip(abc_Controller.selectAction.action.ReadValue<float>());
        h_Hand.SetTrigger(abc_Controller.activateAction.action.ReadValue<float>());
    }
}
