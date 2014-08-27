using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;

public class Tower : MonoBehaviour
{
    public enum TYPE
    {
        basic
    }

    public enum BEHAVIOR
    {
        first,
        last,
        strongest,
        weakest,
        closest
    };



    public GameObject Projectile;

    protected TYPE _type;
    public TYPE Type
    {
        get { return _type; }
        set { _type = value; }
    }

    protected BEHAVIOR _behavior;
    public BEHAVIOR Behavior
    {
        get { return _behavior; }
        set { _behavior = value; }
    }

    protected int _damage;
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    protected float _fireRate;
    public float FireRate
    {
        get { return _fireRate; }
        set { _fireRate = value; }
    }

    protected float _range;
    public float Range
    {
        get { return _range; }
        set { _range = value; }
    }

    protected bool _isAlive;
    public bool IsAlive
    {
        get { return _isAlive; }
        set { _isAlive = value; }
    }

    protected AIRig _aiRig;
    public AIRig AIRig
    {
        get { return _aiRig; }
        set { _aiRig = value; }
    }

    protected GameObject _target;
    public GameObject Target
    {
        get { return _target; }
        set { _target = value; }
    }

    /// <summary>
    /// Common code for all Enemy objects to function.
    /// Calls Initialize which should be overriden.
    /// </summary>
    void Start()
    {
        _isAlive = true;

        _aiRig = gameObject.GetComponentInChildren<AIRig>();

        Initialize();
    }

    /// <summary>
    /// Function to override when making sub towers.
    /// TYPE _type
    /// BEHAVIOR _behavior
    /// float _fireRate
    /// 
    /// Then call Finish();
    /// </summary>
    void Initialize()
    {
        _type = TYPE.basic;
        _behavior = BEHAVIOR.first;
        _fireRate = 1f;
        Finish();
    }

    /// <summary>
    /// Called at the end of Initialize().
    /// </summary>
    void Finish()
    {
        if (_fireRate != 0)
        {
            Debug.LogWarning("KNOWN BUG: Towers instantly fire 2 (instead of 1) projectiles on instantiation");
            InvokeRepeating("Fire", 0, (1 / _fireRate));
        }
    }

    void Update()
    {
        if (!IsAlive)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// function called every (1 / _fireRate) seconds.
    /// </summary>
    void Fire()
    {
        _target = _aiRig.AI.WorkingMemory.GetItem<GameObject>("towerTarget");

        if (_target != null)
        {
            // create projectile from Projectile prefab attached
            GameObject projectile = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;

            // set its target
            projectile.GetComponent<Projectile>().Target = _target.transform;
        }
    }
}