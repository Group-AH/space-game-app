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

        // Start is called before the first frame update
        void Start()
        {
            //anim = gameObject.GetComponentInChildren<Animator>();
            healthBar = GetComponentInChildren<EnemyHealthBar>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {  
                TakeDamage(1);
            }
           
        }

        public void TakeDamage(float damage) { 
            health-=damage;
            healthBar.UpdateHealthBar(health, maxHealth);
        }

    
    }
}
