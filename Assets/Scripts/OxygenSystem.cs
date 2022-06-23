using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BNG
{
    public class OxygenSystem : MonoBehaviour
    {
        [SerializeField]
        public float i_PlayerOxygen;

        GameObject go_PlayerReference;

        [SerializeField]
        Text t_OxygenText;

        [SerializeField]
        GameObject go_GameOverScreen;

        void Start()
        {
            go_PlayerReference = GameObject.FindGameObjectWithTag("Player");

            InvokeRepeating("Subtract", 1f, 1f);
        }

        private void Update()
        {
            t_OxygenText.text = "Current Oxygen level: " + i_PlayerOxygen.ToString();

            if (i_PlayerOxygen <= 0)
            {
                i_PlayerOxygen = 0;

                go_PlayerReference.GetComponentInChildren<LocomotionManager>().enabled = false;
                go_PlayerReference.GetComponentInChildren<PlayerRotation>().enabled = false;
                go_PlayerReference.GetComponentInChildren<AudioSource>().enabled = false;
                go_PlayerReference.GetComponentInChildren<PlayerClimbing>().enabled = false;
                go_PlayerReference.GetComponentInChildren<PlayerMovingPlatformSupport>().enabled = false;
                go_PlayerReference.GetComponentInChildren<TempratureSystem>().enabled = false;
                go_PlayerReference.GetComponentInChildren<OxygenSystem>().enabled = false;

                go_GameOverScreen.SetActive(true);
            }

            if(i_PlayerOxygen >= 100)
            {
                i_PlayerOxygen = 100;
            }
        }

        void Subtract()
        {
            i_PlayerOxygen -= .5f;
        }
    }

}

