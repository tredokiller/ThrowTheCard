using DG.Tweening;

namespace Common.Timer
{
    public static class Timer
    {
        public delegate void TimerFinished();
        
        public static Tween StartTimer(float duration, TimerFinished callback)
        {
            float timer = 0f;
            
            var tween = DOTween.To(() => timer, x => timer = x, 1f, duration)
                .SetEase(Ease.Linear)
                .OnComplete(() => callback());
            return tween;
        }
    }
}