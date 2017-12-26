using UnityEngine;

public class Gear : MonoBehaviour
{
    public float virtualSpeed = 2;
    public float realSpeed = -2;

    void Update()
    {
        if (!Hero.instance.canMove)
        {
            float xAxis = Input.GetAxis("Horizontal");
            Vector2 vel = Hero.instance._Rigidbody2D.velocity;
            vel.x = xAxis*Hero.instance._MoveSpeed;
            Hero.instance.Flip(vel.x);
            switch (World_3.instance._worldState)
            {
                case World_3.WorldState.REAL:
                    vel.x += realSpeed;
                    break;
                case World_3.WorldState.VIRTUAL:
                    vel.x += virtualSpeed;
                    break;
            }
            Hero.instance._Rigidbody2D.velocity = vel;
        }
    }

    void OnCollisionStay2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            Hero.instance.canMove = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            Hero.instance.canMove = true;
        }
    }
}