using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimation : MonoBehaviour {
    private const string STATE = "State";
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        Player.Instance.OnUpdateAnimation += Player_OnUpdateAnimation;
    }

    private void Player_OnUpdateAnimation(object sender, Player.OnUpdateAnimationEventArgs e) {
        animator.SetInteger(STATE, (int) e.movementState);
    }
}
