using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EventAudioTrigger : MonoBehaviour
{
    [SerializeField]
    AudioSource as_VoiceLine;

    private bool b_hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {

        if (b_hasPlayed == false)
        {
            b_hasPlayed = true;
            as_VoiceLine.Play();
        }


    }
}
