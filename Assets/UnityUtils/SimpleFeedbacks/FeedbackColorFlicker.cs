//using DG.Tweening;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FeedbackColorFlicker : BaseFeedback
//{
//    public Color flickerColor = Color.red;
//    public float flickerDuration;

//    public SpriteRenderer m_renderer;

//    private Tweener colorFlicker;

//    private void Start()
//    {
//        OnTrigger();
//        colorFlicker.Complete();
//    }

//    protected override void OnTrigger()
//    {
//        base.OnTrigger();
//        ColorFlicker(flickerDuration);
//        isPlaying = false;
//    }

//    public void ColorFlicker(float time)
//    {
//        m_renderer.color = Color.white;

//        if (colorFlicker != null)
//        {
//            colorFlicker.Restart();
//            return;
//        }

//        m_renderer.color = flickerColor;

//        if (time > 0)
//        {
//            float duration = 0.1f;
//            int loop = (int)(time / duration);
//            if (loop < 1) loop = 1;

//            colorFlicker = m_renderer.DOColor(Color.white, duration).SetEase(Ease.InOutSine).SetLoops(loop, LoopType.Yoyo).OnComplete(()=>m_renderer.color = Color.white).SetAutoKill(false).SetLink(gameObject);
//        }
//        else
//        {
//            colorFlicker = m_renderer.DOColor(Color.white, 0.1f).SetEase(Ease.InQuad).SetAutoKill(false).SetLink(gameObject);
//        }
//    }
//}
