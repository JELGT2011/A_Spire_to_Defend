using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour, IProjectile
{
    public enum TYPE
    {
        basic
    }

    public TYPE Type;

    public int Damage;

    public bool IsAlive;

    public float Speed;

    public GameObject Target;

    /// <summary>
    /// Override when making sub projectiles, then call Initialize()
    /// 
    /// int _damage
    /// float _speed
    /// </summary>
    void Start()
    {
        Damage = 1;
        Speed = 5f;

        Initialize();
    }

    /// <summary>
    /// Initializes functions based on inputed start values.
    /// Do not override.
    /// </summary>
    void Initialize()
    {
        IsAlive = true;
    }

    void Update()
    {
        if (!IsAlive)
        {
            Destroy(transform.root.gameObject);
        }
        else if (Target != null)
        {
            // chase the target
            transform.root.LookAt(Target.transform.position);
            transform.root.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        else {
            // target was destroyed
            transform.root.Translate(Vector3.forward * Speed * Time.deltaTime);
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
        IEnemy enemy;

        collisionObject = collision.collider.transform.root.gameObject;

        if ((enemy = (collisionObject.GetComponentInChildren(typeof(IEnemy))) as IEnemy) != null)
        {
            
        }

        IsAlive = false;
    }
}
