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

        // Start is called before the first frame update
        void Start()
        {
            anim = gameObject.GetComponent<Animator>();
            healthBar = GetComponentInChildren<EnemyHealthBar>();
        }

        void Update(){
            if (health <= 0){
                Die();
            }
        }

        public void TakeDamageEnemy(float damage) { 
            health-=damage;
            healthBar.UpdateHealthBar(health, maxHealth);
        
        }

        void Die(){
            Destroy(gameObject);
        }

    
    }
}
