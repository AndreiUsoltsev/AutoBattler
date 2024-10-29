using PrimeTween;
using TMPro;
using UnityEngine;

namespace CodeBase.Extensions
{
    public static class TweenExtensions
    {
        public static Tween NumbericText(TMP_Text text, float startValue, float endValue, float duration, Ease ease = Ease.Default) 
            => Tween.Custom(startValue, endValue, duration, onValueChange: (float t) => text.text = t.ToString(), ease);
        public static Tween NumbericText(TMP_Text text, int startValue, int endValue, float duration, Ease ease = Ease.Default) 
            => Tween.Custom(startValue, endValue, duration, onValueChange: (float t) => text.text = ((int)t).ToString());
        public static Tween NumbericText(string text, float startValue, float endValue, float duration, Ease ease = Ease.Default)
            => Tween.Custom(startValue, endValue, duration, onValueChange: (float t) => text = t.ToString());
        public static Tween NumbericText(string text, int startValue, int endValue, float duration, Ease ease = Ease.Default)
            => Tween.Custom(startValue, endValue, duration, onValueChange: (float t) => text = ((int)t).ToString());

        public static Sequence ScaleBlinking(Transform target, Vector3 startValue, Vector3 peakValue, float duration, Ease ease = Ease.Default)
        {
            target.localScale = startValue;

            return Tween.Scale(target, peakValue, duration / 2f, ease)
                .Chain(Tween.Scale(target, startValue, duration / 2f, ease));
        }

        public static Tween MoveCurved(Transform target, Vector3 endPoint, MoveCurvedSettings moveCurvedSettings)
        {
            Vector3 startPosition = target.position;
            
            return Tween.Custom(0f, 1f, moveCurvedSettings.Duration, (float t) => SetCurvedPosition(t, target, startPosition, endPoint, moveCurvedSettings));
        }

        private static void SetCurvedPosition(float time, Transform transform, Vector3 startPosition, Vector3 targetPosition, MoveCurvedSettings moveCurvedSettings)
        {
            AnimationCurve animationCurve = moveCurvedSettings.AnimationCurve;
            float totaCurveTime = animationCurve.keys[animationCurve.keys.Length - 1].time;
            float curvedTime = animationCurve.Evaluate(Mathf.Lerp(0, totaCurveTime, time));

            float x = Mathf.LerpUnclamped(startPosition.x, targetPosition.x, moveCurvedSettings.UseXCurved ? curvedTime : time);
            float y = Mathf.LerpUnclamped(startPosition.y, targetPosition.y, moveCurvedSettings.UseYCurved ? curvedTime : time);
            float z = Mathf.LerpUnclamped(startPosition.z, targetPosition.z, moveCurvedSettings.UseZCurved ? curvedTime : time);

            transform.position = new Vector3(x, y, z);  
        }
    }
}