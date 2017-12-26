using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;

public class Hero : Actor
{
    public static Hero instance;

    #region Show In Inspector

    [Header("地面检测配置")] [SerializeField] private LayerMask _whatIsGround;

    [SerializeField] private GameObject _dustPrefab;

    #endregion

    #region Hide In Inspector

    private Animator _animator;
    private bool _isOnGround = false;
    [SerializeField]
    public bool canMove = true;
    #endregion

    #region Init Part

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Init()
    {
        instance = this;
        base.Init();
        _animator = GetComponent<Animator>();
        ProCamera2D.Instance.AddCameraTarget(transform);
    }

    #endregion

    

    #region Update Part

    protected override void Update()
    {
        base.Update();
        InputUpdate();
    }

    protected virtual void InputUpdate()
    {
        List<Command> commands = InputHandler.HandleInput();
        for (int i = 0; i < commands.Count; i++)
        {
            commands[i].Execute(this);
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    #endregion

    #region Collision Part

    protected override void OnCollisionEnter2D(Collision2D collider2D)
    {
        base.OnCollisionEnter2D(collider2D);

        CommonCollisionEnter(collider2D);
    }

    protected override void OnCollisionStay2D(Collision2D collider2D)
    {
        base.OnCollisionStay2D(collider2D);
    }

    protected override void OnCollisionExit2D(Collision2D collider2D)
    {
        base.OnCollisionExit2D(collider2D);
    }

    protected override void OnTriggerEnter2D(Collider2D collider2D)
    {
        base.OnTriggerEnter2D(collider2D);
    }

    protected override void OnTriggerStay2D(Collider2D collider2D)
    {
        base.OnTriggerStay2D(collider2D);
    }

    protected override void OnTriggerExit2D(Collider2D collider2D)
    {
        base.OnTriggerExit2D(collider2D);
    }

    protected void CommonCollisionEnter(Collision2D collider2D)
    {
        _isOnGround = CheckGround();
        if (_isOnGround)
        {
            if (_dustPrefab)
            {
                Instantiate(_dustPrefab, _Collider2D.bounds.min, Quaternion.identity);
            }
        }
    }

    protected void CommonCollisionStay(Collision2D collider2D)
    {
        _isOnGround = CheckGround();
    }

    protected void CommonCollisionExit(Collision2D collider2D)
    {
        _isOnGround = CheckGround();
    }

    #endregion

    #region Function Part

    public override void Move(float x)
    {
        if (!canMove)
        {
            return;
        }
        base.Move(x);
        if (x != 0)
        {
            _animator.SetBool("isWalk", true);
        }
        else
        {
            _animator.SetBool("isWalk", false);
        }
    }

    public override void Attack()
    {
        base.Attack();
    }

    public override void Jump()
    {
        _isOnGround = CheckGround();
        if (!_isOnGround)
        {
            return;
        }
        base.Jump();
    }

    public override void GetHit(float damage)
    {
        base.GetHit(damage);
    }

    public override void Die()
    {
        base.Die();
    }

    protected bool CheckGround()
    {
        Vector2 pos = _Collider2D.bounds.min;
        Vector2 extents = _Collider2D.bounds.extents;
        Vector2 left = new Vector2(pos.x - extents.x + 0.01f, pos.y);
        Vector2 right = new Vector2(pos.x + extents.x - 0.01f, pos.y);
        RaycastHit2D raycastHitMid = Physics2D.Raycast(pos, Vector2.down, 0.1f, _whatIsGround);
        RaycastHit2D raycastHitLeft = Physics2D.Raycast(left, Vector2.down, 0.1f, _whatIsGround);
        RaycastHit2D raycastHitRight = Physics2D.Raycast(right, Vector2.down, 0.1f, _whatIsGround);
        if (raycastHitMid || raycastHitLeft || raycastHitRight)
        {
            return true;
        }
        return false;
    }

    #endregion

    
}