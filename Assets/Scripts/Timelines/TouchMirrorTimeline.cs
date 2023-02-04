using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TouchMirrorTimeline : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private ParticleSystem lightParticleSystem1;
    [SerializeField] private ParticleSystem lightParticleSystem2;


    public void PlayTimeline(CharacterController adult, CharacterController kid)
    {
        lightParticleSystem1.Play();
        lightParticleSystem2.Play();
        CameraManager.Instance.RotateAnimation();
        TimelineAsset timelineAsset = (TimelineAsset) playableDirector.playableAsset;
        TrackAsset track = timelineAsset.GetOutputTrack(0);
        playableDirector.SetGenericBinding(track, adult.CharacterAnimator.Animator);
        TrackAsset track2 = timelineAsset.GetOutputTrack(1);
        playableDirector.SetGenericBinding(track2, kid.CharacterAnimator.Animator);
        playableDirector.Play();
    }
}