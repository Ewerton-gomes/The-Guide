using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideIA : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform player;
    public float speed;
    [SerializeField] Transform guideTransform;
    private enum StateMachine
    {
        Follow,
        Idle,
    }
    private StateMachine stateMachine;
    void Start()
    {
        if (rb == null)
        {
            rb = this.GetComponent<Rigidbody2D>();
        }
        stateMachine = StateMachine.Idle;
    }
    void Update()
    {
        Move(player);
    }

    public void Move(Transform destiny)
    {
        Vector2 target = new Vector2(destiny.position.x - 3, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
}
