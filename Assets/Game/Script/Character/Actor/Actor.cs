using UnityEngine;

public class Actor : MonoBehaviour
{
    #region Show In Inspector

    [Header("基础属性")] [SerializeField] public float _MoveSpeed;

    [SerializeField] protected float _Str;

    [SerializeField]
    protected Vector2 _JumpForce;

    [SerializeField]
    protected float _Hp;
    #endregion

    #region Hide In Inspector

    public Rigidbody2D _Rigidbody2D;
    protected Collider2D _Collider2D;
    protected Animator _Animator;

    #endregion

    #region Init Part

    protected virtual void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _Collider2D = GetComponent<Collider2D>();
        _Animator = GetComponent<Animator>();
    }

    #endregion

    #region Update Part

    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {

    }

    #endregion

    #region Collision Part

    protected virtual void OnCollisionEnter2D(Collision2D collider2D)
    {

    }

    protected virtual void OnCollisionStay2D(Collision2D collider2D)
    {

    }

    protected virtual void OnCollisionExit2D(Collision2D collider2D)
    {

    }

    protected virtual void OnTriggerEnter2D(Collider2D collider2D)
    {

    }

    protected virtual void OnTriggerStay2D(Collider2D collider2D)
    {

    }

    protected virtual void OnTriggerExit2D(Collider2D collider2D)
    {

    }

    #endregion

    #region Function Part

    public virtual void Move(float x)
    {
        Vector2 vel = _Rigidbody2D.velocity;
        vel.x = x * _MoveSpeed;
        _Rigidbody2D.velocity = vel;
        Flip();
    }

    public virtual void Attack()
    {

    }

    public virtual void Jump()
    {
        _Rigidbody2D.AddForce(_JumpForce);
    }

    public virtual void GetHit(float damage)
    {
        _Hp -= damage;
        if (_Hp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        
    }

    public virtual void Flip(float vel = 0)
    {
        float x = _Rigidbody2D.velocity.x;
        if (vel != 0)
        {
            x = vel;
        }
        
        Vector3 scale = transform.localScale;
        if (x > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }else if (x < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    #endregion
}