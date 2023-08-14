using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {
    private const string DEATH_TAG = "Trap";
    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start() {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag(DEATH_TAG)) {
            deathSoundEffect.Play();
            Die();
        }
    }

    private void Die() {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Death");
        PlayerPrefs.DeleteAll();
    }  

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
