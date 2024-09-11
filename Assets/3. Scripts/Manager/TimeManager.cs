using System;
using UnityEngine;
using Utils;

namespace Manager
{
    public class TimeManager : Singleton<TimeManager>
    {
        public enum TimeMode
        {
            NORMAL,
            FAST,
            SLOW,
            STOP,
            NONE,
        }
        private float _beforeTimeScale = 1.0f;
        private TimeMode _mode;

        private void Update()
        {
            switch (_mode)
            {
                case TimeMode.NORMAL:
                    break;
                case TimeMode.FAST:
                    break;
                case TimeMode.SLOW:
                    break;
                case TimeMode.STOP:
                    break;
            }

        }
        public void Enable(float speed)
        {
            _beforeTimeScale = Time.timeScale;
            Time.timeScale = speed;

            if (speed > 1.0f)
                _mode = TimeMode.FAST;
            else if (speed == 0)
                _mode = TimeMode.STOP;
            else if (speed < 1.0f)
                _mode = TimeMode.SLOW;
            else
                _mode = TimeMode.NORMAL;

        }
        public void Enable()
        {
            Time.timeScale = _beforeTimeScale;
        }

        public override void Init()
        {
            _mode = TimeMode.NORMAL;
        }
    }
}