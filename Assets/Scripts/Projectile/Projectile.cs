using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public enum TYPE
    {
        basic
    }

    public TYPE Type { get; set; }

    public int _damage;
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public bool IsAlive { get; set; }

    public GameObject Target { get; set; }

    /// <summary>
    /// Override when making sub projectiles, then call Initialize()
    /// 
    /// int _damage
    /// float _speed
    /// </summary>
    void Start(){
        Initialize();
    }

    /// <summary>
    /// Initializes functions based on inputed start values.
    /// Do not override.
    /// </summary>
    void Initialize(){
        IsAlive = true;
        
    }

    void Update(){
        if (!IsAlive)
        {
            Destroy(transform.root.gameObject);
        }
        else if (Target)
        {
            // chase the target
            transform.root.LookAt(Target.transform.position);
            transform.root.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        else {
            // target was destroyed
            transform.root.Translate(Vector3.forward * Speed * Time.deltaTime);
            IsAlive = false;
        }
    }

    /// <summary>
    /// Only processes collisions with a GameObject that has an Enemy component.
    /// Destroys itself after collision.
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision){
        GameObject collisionObject;

        collisionObject = collision.collider.transform.root.gameObject;

        if ((collisionObject.GetComponentInChildren<Enemy>()) != null){
            IsAlive = false;
        }
    }
}
