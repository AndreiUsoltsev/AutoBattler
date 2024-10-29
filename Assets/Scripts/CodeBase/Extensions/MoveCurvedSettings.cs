using PrimeTween;
using System;
using UnityEngine;

namespace CodeBase.Extensions
{
    [Serializable]
    public struct MoveCurvedSettings
    {
        public float Duration;
        public AnimationCurve AnimationCurve;
        public bool UseXCurved, UseYCurved, UseZCurved;
        public Ease Ease;

        public MoveCurvedSettings(float duration, AnimationCurve animationCurve, bool useXCurved = true, bool useYCurved = true, bool useZCurved = true, Ease ease = Ease.Default)
        {
            Duration = duration;
            AnimationCurve = animationCurve;
            UseXCurved = useXCurved;
            UseYCurved = useYCurved;
            UseZCurved = useZCurved;
            Ease = ease;
        }
    }
}