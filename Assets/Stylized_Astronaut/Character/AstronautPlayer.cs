using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace AstronautPlayer
{

	public class AstronautPlayer : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float health, maxHealth, attackPoints;
		public HealthBar healthBar;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

        public void TakeDamage()
        {
            // Use your own damage handling code, or this example one.
            health -= Mathf.Min(Random.value, health / 4f);
            healthBar.UpdateHealthBar();
        }

        void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update (){
			if (Input.GetKey ("w")) {
				anim.SetInteger ("AnimationPar", 1);
			}  else {
				anim.SetInteger ("AnimationPar", 0);
			}

			if(controller.isGrounded){
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
			}

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;


            // Example so we can test the Health Bar functionality
            if (Input.GetKeyDown(KeyCode.Space))
            {
				Debug.Log(" Pressed");
				TakeDamage();
            }
        }
	}
}
