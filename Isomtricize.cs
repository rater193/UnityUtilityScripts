using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

/*
 * This is a part of rater193's public utility script pack, free for everyone to use!
 * https://github.com/rater193/UnityUtilityScripts
 * */
namespace rater193.utility
{
    [RequireComponent(typeof(SortingGroup))]
    public class Isomtricize : MonoBehaviour
    {
        /*
         * Creator: rater193
         * Creation date: 2022/02/16 @ 1733 EST
         * Description:
         *  This script lets you have an isometric effect in 2d, without changing the "Z" depth. This will keep everything on
         *  one single layer. This is useful because you dont have to worry about specific body parts clipping through the wall
         *  while the other body parts dont. This will apply to the whole object, and child sprites nested inside it.
         * */
        [Tooltip("Default: FALSE; Set this to true, if you want to update the sorting order every \"Fixed Update\". Otherwise, if you just want to call it on the initial frame set it to false.")]
        public bool updateConstantly = false;

        //This is our script to reference our sorting group (Required from the event above the class)
        private SortingGroup group;

        // Start is called before the first frame update
        void Start()
        {
            //First we will make sure we call our group, so we know what to reference
            group = GetComponent<SortingGroup>();

            //First update for setting the depth
            SetDepth();

            //If we want to update constantly, then we will add a "FixedUpdate" coroutine that loops constantly to set the depth
            //every fixed update.
            if (updateConstantly)
            {
                StartCoroutine(FixedUpdateDepth());
            }
        }

        void SetDepth()
        {
            //Lofic for setting the depth in the single layer
            group.sortingOrder = -Mathf.FloorToInt(transform.position.y * 64);
        }

        IEnumerator FixedUpdateDepth()
        {
            //Logic for constantly updating every fixed update.
            //Because we are using a coroutine, we can just yield for the fixed update, then repeat the loop.
            while (true)
            {
                yield return new WaitForFixedUpdate();
                SetDepth();
            }
        }
    }
}
