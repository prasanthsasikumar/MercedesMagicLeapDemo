// %BANNER_BEGIN%
// ---------------------------------------------------------------------
// %COPYRIGHT_BEGIN%
//
// Copyright (c) 2018 Magic Leap, Inc. All Rights Reserved.
// Use of this file is governed by the Creator Agreement, located
// here: https://id.magicleap.com/creator-terms
//
// %COPYRIGHT_END%
// ---------------------------------------------------------------------
// %BANNER_END%

using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.MagicLeap
{
    ///<summary>
    /// Script used to position this Canvas object directly in front of the user by
    /// using lerp functionality to give it a smooth look. Components on the canvas
    /// should function normally.
    ///</summary>
    [RequireComponent(typeof(Canvas))]
    public class HandCanvas : MonoBehaviour
    {
        #region Public Variables
        [Tooltip("The distance from the camera that this object should be placed.")]
        public float CanvasDistance = 1.5f;

        [Tooltip("The speed at which this object changes it's position.")]
        public float PositionLerpSpeed = 5f;

        
        [Tooltip("The speed at which this object changes it's rotation.")]
        public float RotationLerpSpeed = 5f;
        [Tooltip("The hand this object will be in front of")]
        public GameObject _leftHand, _rightHand;

        [Tooltip("The camera this object will be facing")]
        public GameObject _camera;

        [SerializeField, Tooltip("KeyPose to track.")]
        public MLHandKeyPose _keyPoseToTrack;

        [Space, SerializeField, Tooltip("Flag to specify if left hand should be tracked.")]
        public bool _trackLeftHand = true;

        [SerializeField, Tooltip("Flag to specify id right hand should be tracked.")]
        public bool _trackRightHand = true;

        [SerializeField, Tooltip("Time to make a handgesture valid")]
        public float gestureTimeLimit = 1f;
        #endregion

        #region Private Varibles
        // The canvas that is attached to this object.
        private Canvas _canvas;
        private GameObject _hand;
        

        #endregion

        #region Unity Methods
        /// <summary>
        /// Initializes variables and verifies that necesary components exist.
        /// </summary>
        void Awake()
        {
            _canvas = GetComponent<Canvas>();

            // Disable this component if
            // it failed to initialzie properly.
            if (_canvas == null)
            {
                Debug.LogError("Error: HeadposeCanvas._canvas is not set, disabling script.");
                enabled = false;
                return;
            }
            if(_leftHand == null)
            {
                Debug.LogError("Error: right hand is not set, disabling script.");
                enabled = false;
                return;
            }
            if (_rightHand == null)
            {
                Debug.LogError("Error: right hand is not set, disabling script.");
                enabled = false;
                return;
            }
        }

        /// <summary>
        /// Update position and rotation of this canvas object to face the camera using lerp for smoothness.
        /// </summary>
        void Update()
        {            
            float confidenceLeft = _trackLeftHand ? GetKeyPoseConfidence(MLHands.Left) : 0.0f;
            float confidenceRight = _trackRightHand ? GetKeyPoseConfidence(MLHands.Right) : 0.0f;
            //Debug.Log(confidenceLeft + confidenceRight);
        }

        private float GetKeyPoseConfidence(MLHand hand)
        {           
            if (hand != null)
            {
                if(hand.HandType == MLHandType.Right)
                {
                    _hand = _rightHand;
                }
                else
                {
                    _hand = _leftHand;
                }
                
                
                if (hand.KeyPose == _keyPoseToTrack)
                {
                    //use bar before this

                    //no defined hand gesture for 2 seconds - reset
                    
                    // Move the object CanvasDistance units in front of the camera.
                    float posSpeed = Time.deltaTime * PositionLerpSpeed;
                    Vector3 posTo = _hand.transform.position;
                    transform.position = Vector3.SlerpUnclamped(transform.position, posTo, posSpeed);

                    // Rotate the object to face the camera.
                    float rotSpeed = Time.deltaTime * RotationLerpSpeed;
                    Quaternion rotTo = Quaternion.LookRotation(transform.position - _camera.transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotTo, rotSpeed);

                    return hand.KeyPoseConfidence;
                }
            }
            return 0.0f;
        }
                

        #endregion
    }
}
