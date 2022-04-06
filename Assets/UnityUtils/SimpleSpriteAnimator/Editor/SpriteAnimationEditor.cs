using UnityEngine;
using UnityEditorInternal;
using UnityEditor;

namespace SimpleSpriteAnimator
{
    [CustomEditor(typeof(SpriteAnimation))]
    public class SpriteAnimationEditor : Editor
    {
        private SpriteAnimation SelectedSpriteAnimation
        {
            get { return target as SpriteAnimation; }
        }

        private float timeTracker = 0;

        private Sprite currentFrame;

        float animationTime;

        private void OnEnable()
        {
            EditorApplication.update -= OnUpdate;
            EditorApplication.update += OnUpdate;
        }

        private void OnDisable()
        {
            EditorApplication.update -= OnUpdate;
        }

        public override bool HasPreviewGUI()
        {
            return HasAnimationAndFrames();
        }

        public override bool RequiresConstantRepaint()
        {
            return HasAnimationAndFrames();
        }

        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            if (currentFrame != null)
            {
                Texture t = currentFrame.texture;
                Rect tr = currentFrame.textureRect;
                Rect r2 = new Rect(tr.x / t.width, tr.y / t.height, tr.width / t.width, tr.height / t.height);

                Rect previewRect = r;

                float targetAspectRatio = tr.width / tr.height;
                float windowAspectRatio = r.width / r.height;
                float scaleHeight = windowAspectRatio / targetAspectRatio;

                if (scaleHeight < 1f)
                {
                    previewRect.width = r.width;
                    previewRect.height = scaleHeight * r.height;
                    previewRect.x = r.x;
                    previewRect.y = r.y + (r.height - previewRect.height) / 2f;
                }
                else
                {
                    float scaleWidth = 1f / scaleHeight;

                    previewRect.width = scaleWidth * r.width;
                    previewRect.height = r.height;
                    previewRect.x = r.x + (r.width - previewRect.width) / 2f;
                    previewRect.y = r.y;
                }

                GUI.DrawTextureWithTexCoords(previewRect, t, r2, true);
            }
        }

        private bool HasAnimationAndFrames()
        {
            return SelectedSpriteAnimation != null && SelectedSpriteAnimation.Frames.Length > 0;
        }

        private void OnUpdate()
        {
            if (SelectedSpriteAnimation.Frames.Length > 0 && SelectedSpriteAnimation.FPS > 0)
            {
                if (timeTracker == 0f)
                {
                    timeTracker = (float)EditorApplication.timeSinceStartup;
                }

                float deltaTime = (float)EditorApplication.timeSinceStartup - timeTracker;
                timeTracker = (float)EditorApplication.timeSinceStartup;

                animationTime += deltaTime * SelectedSpriteAnimation.FPS;
                currentFrame = SelectedSpriteAnimation.GetAnimationFrame(animationTime);
            }
        }
    }
}