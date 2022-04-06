using UnityEngine;
using System.Collections.Generic;

namespace SimpleSpriteAnimator
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimator : MonoBehaviour
    {
        [SerializeField]
        private SpriteAnimation[] spriteAnimations;

        [SerializeField]
        private bool playAutomatically = true;

        private SpriteAnimation DefaultAnimation
        {
            get { return spriteAnimations.Length > 0 ? spriteAnimations[0] : null; }
        }

        public bool IsPlaying
        {
            get; private set;
        }

        public SpriteAnimation CurrentAnimation { get; private set; }

        private SpriteRenderer spriteRenderer;

        private float animationTime = 0.0f;

        private int currentFrame = -1;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            if (playAutomatically)
            {
                Play(DefaultAnimation);
            }
        }

        void OnBecameVisible()
        {
            enabled = true;
        }

        private void Update()
        {
            if (spriteRenderer.isVisible == false)
                enabled = false;

            if (IsPlaying)
            {
                animationTime += Time.deltaTime * CurrentAnimation.FPS;

                int newFrame = CurrentAnimation.GetCurrentFrame(animationTime);
                if (currentFrame != newFrame)
                {
                    currentFrame = newFrame;
                    spriteRenderer.sprite = CurrentAnimation.Frames[currentFrame];
                }
            }
        }

        public void Play()
        {
            if (CurrentAnimation == null)
                Play(DefaultAnimation);
            else
                IsPlaying = true;
        }

        public void Play(int index)
        {
            Play(GetAnimationByIndex(index));
        }

        public void Play(SpriteAnimation animation)
        {
            IsPlaying = true;
            ChangeAnimation(animation);
        }

        private SpriteAnimation GetAnimationByIndex(int index)
        {
            if (spriteAnimations.Length == 0) return null;

            index = Mathf.Clamp(index, 0, spriteAnimations.Length - 1);
            return spriteAnimations[index];

        }

        public void ChangeAnimation(SpriteAnimation spriteAnimation)
        {
            animationTime = 0f;
            currentFrame = -1;
            CurrentAnimation = spriteAnimation;
        }
    }
}
