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

    protected Transform _target;
    public Transform Target
    {
        get { return _target; }
        set { _target = value; }
    }

    /// <summary>
    /// Common code for all Projectile objects to function.
    /// Calls Initialize which should be overriden.
    /// </summary>
    void Start()
    {
        _isAlive = true;
        Initialize();
    }

    /// <summary>
    /// Function to override when making sub projectiles.
    /// int _damage
    /// float _speed
    /// </summary>
    void Initialize()
    {
        _damage = 1;
        _speed = 5f;
        Finish();
    }

    /// <summary>
    /// Called at the end of Initialize().
    /// </summary>
    void Finish()
    {

    }

    void Update()
    {
        if (!IsAlive)
        {
            Destroy(gameObject);
        }
        else if (_target != null)
        {
            // chase the target
            transform.LookAt(Target.transform.position);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
        else {
            // target was destroyed
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
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

        collisionObject = collision.collider.gameObject;

        if ((enemy = collisionObject.GetComponent<Enemy>()) != null)
        {
            
        }

        _isAlive = false;
    }
}
