using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BNG
{
    public class TempratureSystem : MonoBehaviour
    {
        [SerializeField]
        public float i_PlayerTemp;

        GameObject go_PlayerReference;

        [SerializeField]
        Text t_TempratureText;

        [SerializeField]
        GameObject go_GameOverScreen;

        void Start()
        {
            go_PlayerReference = GameObject.FindGameObjectWithTag("Player");

            InvokeRepeating("Subtract", 1f, 1f);
        }


        private void Update()
        {
            t_TempratureText.text = "Curren temprature: " + i_PlayerTemp.ToString();

            if (i_PlayerTemp == 34f)
            {
                //Player Walks Slower
            }

            if (i_PlayerTemp <= 0)
            {
                i_PlayerTemp = 0;

                go_PlayerReference.GetComponentInChildren<LocomotionManager>().enabled = false;
                go_PlayerReference.GetComponentInChildren<PlayerRotation>().enabled = false;
                go_PlayerReference.GetComponentInChildren<AudioSource>().enabled = false;
                go_PlayerReference.GetComponentInChildren<PlayerClimbing>().enabled = false;
                go_PlayerReference.GetComponentInChildren<PlayerMovingPlatformSupport>().enabled = false;
                go_PlayerReference.GetComponentInChildren<TempratureSystem>().enabled = false;
                go_PlayerReference.GetComponentInChildren<OxygenSystem>().enabled = false;

                go_GameOverScreen.SetActive(true);
            }

            if (i_PlayerTemp >= 37)
            {
                i_PlayerTemp = 37;
            }
        }

        void Subtract()
        {
            i_PlayerTemp -= .1f;
        }
    }

}

