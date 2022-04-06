//using Cinemachine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(CinemachineImpulseSource))]
//public class FeedbackImpulseSource : BaseFeedback
//{
//    //#if UNITY_EDITOR
//    //    private void OnValidate()
//    //    {
//    //        if (source == null)
//    //            source = GetComponent<CinemachineImpulseSource>();
//    //    }
//    //#endif

//    private CinemachineImpulseSource source;

//    public float m_AmplitudeGain = 1f;
//    public float m_FrequencyGain = 1f;
//    public float m_SustainTime = 0.2f;
//    public float m_ImpactRadius = 7;
//    public float m_DissipationDistance = 14;
//    //public float m_PropagationSpeed = 343;


//    // Start is called before the first frame update
//    void Awake()
//    {
//        source = GetComponent<CinemachineImpulseSource>();

//        var m_ImpulseDefinition = source.m_ImpulseDefinition;

//        m_ImpulseDefinition.m_AmplitudeGain = m_AmplitudeGain;
//        m_ImpulseDefinition.m_FrequencyGain = m_FrequencyGain;

//        m_ImpulseDefinition.m_TimeEnvelope.m_SustainTime = m_SustainTime;

//        m_ImpulseDefinition.m_ImpactRadius = m_ImpactRadius;
//        m_ImpulseDefinition.m_DissipationDistance = m_DissipationDistance;

//    }

//    protected override void OnTrigger()
//    {
//        isPlaying = false;
//        source.GenerateImpulse();
//    }

//}
