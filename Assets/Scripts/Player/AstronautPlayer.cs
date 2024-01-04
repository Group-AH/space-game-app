using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

namespace AstronautPlayer
{
    public class AstronautPlayer : MonoBehaviour
    {
        private Animator anim;
        private CharacterController controller;

        public float health, maxHealth, attackPoints;
        public HealthBar healthBar;

        public float forwardSpeed = 6.0f;
        public float strafeSpeed = 4.0f;

        private Vector3 moveDirection = Vector3.zero;
        private Vector3 jump = Vector3.zero;
        public float gravity = 20.0f;
        public float jumpAcc = 40.0f;

        private bool gameOver;
        public Menus gameOverMenu;

        public List<string> droppedItems = new List<string>();

        void TakeDamagePlayer(float damage)
        {
            health -= damage;
            healthBar.UpdateHealthBar();
        }


        void Start()
        {
            controller = GetComponent<CharacterController>();
            anim = gameObject.GetComponentInChildren<Animator>();

            gameOver = false;
        }

        void Update()
        {
            if (Menus.gamePaused) return;
            if (gameOver) return;

            // if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            
            if (Input.GetKey(KeyCode.W))
            {
                // anim.SetBool("Walk", true);
                anim.SetInteger("AnimationPar", 1);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetBool("Run", true);
                }
                else
                {
                    anim.SetBool("Run", false);
                }
            }
            else
            {
                anim.SetBool("Walk", false);
                anim.SetInteger("AnimationPar", 0);
            }

            if (controller.isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // jump
                    anim.SetBool("jumpstart", true);
                    if (anim.GetBool("jumpstart") == true)
                    {
                        anim.SetBool("jumploop", true);
                        jump.y = jumpAcc;
                    }

                    if (anim.GetBool("jumploop") == true)
                    {
                        anim.SetBool("jumpend", true);
                    }
                }
                else
                {
                    anim.SetBool("jumpstart", false);
                }

                // move
                moveDirection = transform.forward * Input.GetAxis("Vertical") * forwardSpeed
                 + transform.right * Input.GetAxis("Horizontal") * strafeSpeed
                 + jump;
            }

            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);

            if (health <= 0)
            {
                gameOver = true;
                Die();
                Debug.Log("PLAYER DEAD");
            }

        }

        void Die()
        {
            gameOverMenu.ShowGameOver();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("drop"))
            {
                UnityEngine.Debug.Log("Item collided with 'drop' object.");
                GameObject item = other.gameObject;
                string itemName = item.name;
                const string cloneSuffix = "(Clone)";
                if (itemName.EndsWith(cloneSuffix))
                {
                    itemName = itemName.Substring(0, itemName.Length - cloneSuffix.Length);
                }
                droppedItems.Add(itemName);
                Destroy(item);
            }
        }

    }
}
