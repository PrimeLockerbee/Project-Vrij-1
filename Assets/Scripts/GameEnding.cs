using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [SerializeField] GameObject go_PlayerFlag;
    [SerializeField] GameObject go_StaticFlag;
    [SerializeField] GameObject go_EndingScreen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Flag")
        {
            go_StaticFlag.SetActive(true);
            go_EndingScreen.SetActive(true);
            Destroy(go_PlayerFlag);
        }
    }
}
