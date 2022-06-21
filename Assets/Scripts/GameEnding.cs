using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [SerializeField] GameObject go_PlayerFlag;
    [SerializeField] GameObject go_StaticFlag;
    [SerializeField] GameObject go_EndingScreen;

    public float offsetTime = 10f;
    private float timer = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Flag")
        {
            RenderSettings.fog = false;
            go_StaticFlag.SetActive(true);

            timer += Time.deltaTime;
            if (timer > offsetTime)
            {
                timer = 0f;
                go_EndingScreen.SetActive(true);
            }


            Destroy(go_PlayerFlag);
        }
    }
}
