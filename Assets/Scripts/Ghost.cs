using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private SpriteRenderer sprite;
    private  float dirX = 0f;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        

        if( dirX > 0f)
       {
        sprite.flipX = false;
       }
       else if (dirX < 0f)
       {
        sprite.flipX = true;
       }
    }
}
