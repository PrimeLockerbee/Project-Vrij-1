using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class IcePick : GrabbableEvents
    {
        [Header("Raycast Layers")]

        public LayerMask GrappleLayers;

        [Header("Component definitions")]

        public Transform MuzzleTransform;

        CharacterController characterController;
        SmoothLocomotion smoothLocomotion;
        PlayerGravity playerGravity;
        PlayerClimbing playerClimbing;
        Rigidbody playerRigid;

        AudioSource audioSource;

        // Are we currently climbing towards an object
        bool curclimbing = false;
        // Were we climbing last frame
        bool wasclimbing = false;

        bool validTargetFound = false;// Is there something valid to climb on to

        bool isDynamic = false; // Can we climb the object
        Rigidbody climbingTarget; // Object we're climbing
        Collider climbingTargetCollider; // Collider we're climbing
        Transform climbingTargetParent; // Store original parent
        bool requireRelease = false; // Require release to be pressed before continuing
        bool climbing = false; // Have we transitioned to climbing?

        [Header("Show for Debug")]
        // We will use the climbable as our means of moving and pulling the character around
        public Climbable ClimbHelper;

        void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player)
            {
                characterController = player.GetComponentInChildren<CharacterController>();
                smoothLocomotion = player.GetComponentInChildren<SmoothLocomotion>();
                playerGravity = player.GetComponentInChildren<PlayerGravity>();
                playerClimbing = player.GetComponentInChildren<PlayerClimbing>();
                playerRigid = player.GetComponent<Rigidbody>();
            }
            else
            {
                Debug.Log("No player object found.");
            }

            audioSource = GetComponent<AudioSource>();
        }

        // Try to climb
        public void OnCollisionEnter(Collision collision)
        {
            climbPick();
        }

        public override void OnGrab(Grabber grabber)
        {
            base.OnGrab(grabber);
        }

        public override void OnRelease()
        {
            onReleasePick();

            base.OnRelease();
        }

        void climbPick()
        {

            //if (validTargetFound)
            //{
                //if (!climbing)
                //{
                    // Add climbable / grabber
                    ClimbHelper.transform.localPosition = Vector3.zero;
                    playerClimbing.AddClimber(ClimbHelper, thisGrabber);
                    climbing = true;
             //}

           // }
        }

        // Called when climbing previous frame, but not this one
        void onReleasePick()
        {

            // Reset gravity back to normal
            changeGravity(true);

            if (climbingTarget && isDynamic)
            {
                climbingTarget.useGravity = true;
                climbingTarget.isKinematic = false;
                climbingTarget.transform.parent = climbingTargetParent;

                // More reliable method of resetting parent :
                if (climbingTarget.GetComponent<Grabbable>())
                {
                    climbingTarget.GetComponent<Grabbable>().ResetParent();
                }
            }

            // Reset Climbing
            ClimbHelper.transform.localPosition = Vector3.zero;
            playerClimbing.RemoveClimber(thisGrabber);
            climbing = false;

            validTargetFound = false;
            isDynamic = false;
        }

        void changeGravity(bool gravityOn)
        {
            if (playerGravity)
            {
                playerGravity.ToggleGravity(gravityOn);
            }
        }
    }
}