using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        public float health, maxHealth, moveSpeed;
        [SerializeField] EnemyHealthBar healthBar;
        private Animator anim;
        public float shootingRange = 10f;
        public float chasingRange = 15f;
        private GameObject player;
        public GameObject dropItem;

        // Start is called before the first frame update
        void Start()
        {
            anim = gameObject.GetComponent<Animator>();
            healthBar = GetComponentInChildren<EnemyHealthBar>();
            player = GameObject.FindGameObjectWithTag("Player");
        }

        void Update(){
            if (health <= 0){
                Die();
            }

            float playerDistance = Vector3.Distance(transform.position, player.transform.position);

            if (playerDistance <= chasingRange  && playerDistance > shootingRange)
            {
                Chase();
            }

        }

        public void TakeDamageEnemy(float damage) { 
            health-=damage;
            healthBar.UpdateHealthBar(health, maxHealth);
        
        }

        void Chase()
        {
            transform.LookAt(player.transform);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        void Die(){
            Destroy(gameObject);
            float randomNumber = UnityEngine.Random.value;
            if (randomNumber < 0.7f){
                Instantiate(dropItem, transform.position, Quaternion.identity);
            }
        }


    
    }
}
