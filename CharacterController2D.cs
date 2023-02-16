using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is a part of rater193's public utility script pack, free for everyone to use!
 * https://github.com/rater193/UnityUtilityScripts
 * This script was created for the Unity3D Engine.
 * */
namespace rater193.utility
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterController2D : MonoBehaviour
    {
        /*
         * Creator: rater193
         * Creation date: 2022/02/16 @ 1756 EST
         * Description:
         *  This script is a basic 2D character controller you can use to quickly prototype a topdown character movement system
         *  using a rigidbody2d. This is a physical based controller, so it will apply forces to the rigidbody to get it to move.
         *  This is friendly with pause systems in that regard as well.
         * */

        //Variables
        [HideInInspector]
        public Rigidbody2D rigidbody;

        //Singleton
        [HideInInspector]
        public CharacterController2D instance;

        // Start is called before the first frame update
        void Start()
        {
            //Updating the singleton
            instance = this;

            //Updating our component references
            rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            //Checking for inputs, and applying forces
            //Here we are just using the default axis in the default input config for our unity project.
            Vector2 velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            //We can apply any logic to altar the velocity here

            //Now we set the velocity to how fast we want to move the player.
            //Dont set this to use deltatime, because that is already calculated in the physics update.
            rigidbody.velocity = velocity;
        }
    }
}
