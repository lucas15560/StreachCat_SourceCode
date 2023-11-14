using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Vector3Nudger : MonoBehaviour
    {
        public BaseSpringBehaviour Nudgeable;
        public Vector3 NudgeAmount = new Vector3(0, 500, 0);
        public Vector2 NudgeFrequency = new Vector2(2, 10);
        public bool AutoNudge = true;

        private float LastNudgeTime;
        private float NextNudgeFrequency;
        public bool NudgeG;

        private void Awake()
        {
            NextNudgeFrequency = Random.Range(NudgeFrequency.x, NudgeFrequency.y);
        }

        private void Update()
        {
            if (AutoNudge && LastNudgeTime + NextNudgeFrequency < Time.time)
            {
                Nudge();
            }
            if (NudgeG)
            {
                Nudge();
            }
        }

        public void Nudge()
        {
            NudgeG = false;
            (Nudgeable as INudgeable<Vector3>).Nudge(NudgeAmount);
            LastNudgeTime = Time.time;
            NextNudgeFrequency = Random.Range(NudgeFrequency.x, NudgeFrequency.y);
        }
    }