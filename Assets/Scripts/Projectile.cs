using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public enum TYPE
    {
        basic
    }

    protected TYPE _type;
    public TYPE Type
    {
        get { return _type; }
        set { _type = value; }
    }

    protected int _damage;
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    protected bool _isAlive;
    public bool IsAlive
    {
        get { return _isAlive; }
        set { _isAlive = value; }
    }

    protected float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    protected GameObject _target;
    public GameObject Target
    {
        get { return _target; }
        set { _target = value; }
    }

    /// <summary>
    /// Override when making sub projectiles, then call Initialize()
    /// 
    /// int _damage
    /// float _speed
    /// </summary>
    void Start()
    {
        _damage = 1;
        _speed = 5f;

        Initialize();
    }

    /// <summary>
    /// Initializes functions based on inputed start values.
    /// Do not override.
    /// </summary>
    void Initialize()
    {
        _isAlive = true;
    }

    void Update()
    {
        if (!IsAlive)
        {
            Destroy(transform.root.gameObject);
        }
        else if (_target != null)
        {
            // chase the target
            transform.root.LookAt(Target.transform.position);
            transform.root.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
        else {
            // target was destroyed
            transform.root.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Only processes collisions with a GameObject that has an Enemy component.
    /// Destroys itself after collision.
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject;
        Enemy enemy;

        collisionObject = collision.collider.transform.root.gameObject;

        if ((enemy = collisionObject.GetComponentInChildren<Enemy>()) != null)
        {
            
        }

        _isAlive = false;
    }
}
