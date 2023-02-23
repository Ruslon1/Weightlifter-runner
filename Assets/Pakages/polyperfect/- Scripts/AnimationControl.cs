using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolyPerfect
{
    public class AnimationControl : MonoBehaviour
    {
        string currentAnimation = "";
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {


        }
        public void SetAnimation(string animationName)
        {

            if (currentAnimation != "")
            {
                GetComponent<Animator>().SetBool(currentAnimation, false);
            }
            GetComponent<Animator>().SetBool(animationName, true);
            currentAnimation = animationName;
        }

        public void SetAnimationIdle()
        {

            if (currentAnimation != "")
            {
                GetComponent<Animator>().SetBool(currentAnimation, false);
            }


        }
        public void SetDeathAnimation(int numOfClips)
        {

            int clipIndex = Random.Range(0, numOfClips);
            string animationName = "Death";
            Debug.Log(clipIndex);

            GetComponent<Animator>().SetInteger(animationName, clipIndex);
        }
    }
}