using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using RAIN.Core;
using RAIN.Perception.Sensors;
using RAIN.Entities.Aspects;

public class Tower : MonoBehaviour, ITower
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

    public GameObject ProjectileType;

    public TYPE Type;

    public BEHAVIOR Behavior;

    public int Damage;

    public float FireRate;

    public float LastFired;

    public float Range;

    public bool IsAlive;

    public AIRig AIRig;

    public IList<RAINAspect> Targets;

    public GameObject PriorityTarget;

    public VisualSensor VisualSensor;

    /// <summary>
    /// Override the following when making sub towers, then call Initialize()
    /// 
    /// Tower.TYPE _type
    /// Tower.BEHAVIOR _behavior
    /// float _fireRate (do not set to 0)
    /// float _range
    /// </summary>
    void Start()
    {
        Type = TYPE.basic;
        Behavior = BEHAVIOR.first;
        FireRate = 1f;
        Range = 6f;

        Initialize();
    }

    /// <summary>
    /// Initializes functions based on inputed start values.
    /// Do not override.
    /// </summary>
    public void Initialize()
    {
        IsAlive = true;
        LastFired = 0;
        Targets = new List<RAINAspect>();

        AIRig = gameObject.GetComponent<AIRig>();
        VisualSensor = (VisualSensor)AIRig.AI.Senses.GetSensor("_visualSensor");
        VisualSensor.Range = Range;
    }

    void Update()
    {
        if (!IsAlive)
        {
            Destroy(transform.root.gameObject);
        }
        else if ((Time.time - LastFired) >= (1 / FireRate))
        {
            AcquireTarget();

            if (Targets.Count != 0)
            {
                Fire();
            }
        }
        else
        {
            LastFired -= Time.deltaTime;
        }
    }

    void AcquireTarget()
    {
        // get all targets in range of tower from _visualSensor
        Targets = VisualSensor.Matches;

        if (Targets.Count != 0)
        {
            switch (Behavior)
            {
                case BEHAVIOR.first:
                    // lambda functions to reorder _targets based on the behavior
                    Targets.OrderBy(aspect => (aspect.Entity.Form.GetComponentInChildren(typeof(IEnemy)) as IEnemy).Distance);
                    PriorityTarget = Targets.First<RAINAspect>().Entity.Form;
                    break;

                case BEHAVIOR.last:
                    Targets.OrderBy(aspect => (aspect.Entity.Form.GetComponentInChildren(typeof(IEnemy)) as IEnemy).Distance);
                    PriorityTarget = Targets.Last<RAINAspect>().Entity.Form;
                    break;

                case BEHAVIOR.strongest:
                    Targets.OrderBy(aspect => (aspect.Entity.Form.GetComponentInChildren(typeof(IEnemy)) as IEnemy).MaxHealth);
                    PriorityTarget = Targets.First<RAINAspect>().Entity.Form;
                    break;

                case BEHAVIOR.weakest:
                    Targets.OrderBy(aspect => (aspect.Entity.Form.GetComponentInChildren(typeof(IEnemy)) as IEnemy).MaxHealth);
                    PriorityTarget = Targets.Last<RAINAspect>().Entity.Form;
                    break;

                case BEHAVIOR.closest:
                    // RAIN does this by default
                    break;

                default:
                    // will target the closest enemy
                    break;
            }
        }
    }

    /// <summary>
    /// Fires a projectile and prevents refiring for time = (1 / _fireRate).
    /// </summary>
    void Fire()
    {
        // set cooldown
        LastFired = Time.time;

        // create projectile from Projectile prefab attached
        GameObject projectile = Instantiate(ProjectileType, transform.position, Quaternion.identity) as GameObject;

        // set its target
        (projectile.GetComponentInChildren(typeof(IProjectile)) as IProjectile).Target = PriorityTarget;
    }
}