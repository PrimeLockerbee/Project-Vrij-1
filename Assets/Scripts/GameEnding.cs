using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameEnding : MonoBehaviour
{
    [SerializeField] GameObject go_PlayerFlag;
    [SerializeField] GameObject go_StaticFlag;
    [SerializeField] GameObject go_EndingScreen;
    [SerializeField] AudioSource as_EndClip;

    [SerializeField] private float timer = 10f;


    private void Update()
    {
        if (go_StaticFlag.activeSelf)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0f;
                go_EndingScreen.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Flag")
        {
            go_StaticFlag.SetActive(true);
            as_EndClip.Play();
            Destroy(go_PlayerFlag);
        }
    }
}
