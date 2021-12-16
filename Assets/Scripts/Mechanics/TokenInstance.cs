using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using System.Threading.Tasks;
using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using Random=UnityEngine.Random;


namespace Platformer.Mechanics
{
    /// <summary>
    /// This class contains the data required for implementing token collection mechanics.
    /// It does not perform animation of the token, this is handled in a batch by the 
    /// TokenController in the scene.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class TokenInstance : MonoBehaviour
    {
        public AudioClip tokenCollectAudio;
        public AudioSource audioSource;
        [SerializeField] TextMeshProUGUI Attempt1TimeText;
        [SerializeField] TextMeshProUGUI Attempt2TimeText;
        [SerializeField] TextMeshProUGUI Attempt3TimeText;
        public bool preOpenStoneWall;
        [Tooltip("If true, animation will start at a random position in the sequence.")]
        public bool randomAnimationStartTime = false;
        [Tooltip("List of frames that make up the animation.")]
        public Sprite[] idleAnimation, collectedAnimation;

        internal Sprite[] sprites = new Sprite[0];

        internal SpriteRenderer _renderer;

        //unique index which is assigned by the TokenController in a scene.
        internal int tokenIndex = -1;
        internal TokenController controller;
        //active frame in animation, updated by the controller.
        internal int frame = 0;
        internal bool collected = false;
        internal Animator animator;
        [SerializeField] GameObject StoneDoor;
        [SerializeField] GameObject Diamond;
        float startTime = 4f;

        void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();

           if (randomAnimationStartTime)
                frame = Random.Range(0, sprites.Length);
            sprites = idleAnimation;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            //only exectue OnPlayerEnter if the player collides with this token.
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player != null){
                OnPlayerEnter(player);
            }
        }

        public void OnPlayerEnter(PlayerController player)
        {
            sprites = idleAnimation;
        }
        

    }
}