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

		public float forwardSpeed = 6.0f;
		public float strafeSpeed = 4.0f;

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
			if (Input.GetAxis("Vertical") > 0) {
				anim.SetInteger ("AnimationPar", 1);
			}  else {
				anim.SetInteger ("AnimationPar", 0);
			}

			if(controller.isGrounded){
                if (Input.GetKeyDown(KeyCode.Space)) {
                    // jump
                }

                // move
				moveDirection = transform.forward * Input.GetAxis("Vertical") * forwardSpeed
                 + transform.right * Input.GetAxis("Horizontal") * strafeSpeed;
			}

            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
			
            // Example so we can test the Health Bar functionality
            if (Input.GetKeyDown(KeyCode.Space))
            {
				Debug.Log(" Pressed");
				TakeDamage();
            }
        }
	}
}
