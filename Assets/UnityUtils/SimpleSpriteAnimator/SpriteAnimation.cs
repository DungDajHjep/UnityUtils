using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace SimpleSpriteAnimator
{
    [Serializable]
    [CreateAssetMenu]
    public class SpriteAnimation : ScriptableObject
    {

        [SerializeField]
        private int fps = 30;

        public int FPS
        {
            get { return fps; }
            set { fps = value; }
        }

        [SerializeField]
        private Sprite[] frames = new Sprite[0];

        public Sprite[] Frames
        {
            get { return frames; }
        }

        [SerializeField]
        private bool looping = true;
        public bool IsLooping
        {
            get { return looping; }
        }

        public Sprite GetAnimationFrame(float animationTime)
        {
            int currentFrame = 0;

            if (IsLooping)
                currentFrame = GetLoopingFrame(animationTime);
            else
                currentFrame = GetPlayOnceFrame(animationTime);

            return Frames[currentFrame];
        }

        public int GetCurrentFrame(float animationTime)
        {
            int currentFrame = 0;

            if (IsLooping)
                currentFrame = GetLoopingFrame(animationTime);
            else
                currentFrame = GetPlayOnceFrame(animationTime);

            return currentFrame;
        }

        private int GetLoopingFrame(float animationTime)
        {
            return (int)animationTime % Frames.Length;
        }

        private int GetPlayOnceFrame(float animationTime)
        {
            int lastFrame = Frames.Length - 1;
            return animationTime < lastFrame ? (int)animationTime : lastFrame;
        }
    }
}
