using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Tower : MonoBehaviour{
    public enum TYPE
    {
        basic,
        Dome_inator,
        Automated
    }

    public enum BEHAVIOR
    {
        first,
        last,
        strongest,
        weakest,
        closest
    };



    public GameObject _projectileType;
    public GameObject ProjectileType
    {
        get { return _projectileType; }
        set { _projectileType = value; }
    }

	[SerializeField]
	private int cost;

	public int _damage;
	public int Damage
	{
		get { return _damage; }
		set { _damage = value; }
	}

	public float _range;
	
	public float _fireRate;
	public float FireRate
	{
		get { return _fireRate; }
		set { _fireRate = value; }
	}

	public TYPE _type;
	public TYPE Type
	{
		get { return _type; }
		set { _type = value; }
	}

	public float LastFired { get; set; }
	
	public bool IsAlive { get; set; }
	
	public GameObject PriorityTarget { get; set; }
	
	public Transform FiringMount { get; set; }
	
	public List<GameObject> _targets;

	public TowerInfo myInfo;
	public float rotationSpeed = 5f;
	public Transform projectileSource;

	void Start(){
		IsAlive = true;
	}

    void Update(){
        if (!IsAlive)
        {
            Destroy(gameObject);
        }
        else if ((Time.time - LastFired) >= (1 / FireRate))
        {
		
			Enemy enemy = Global.Instance.GetFirstInRange(transform.position,_range);
            
            if (enemy != null)
            {
                Fire(enemy.gameObject);
				//Turn towards
				Quaternion neededRotation = Quaternion.LookRotation(enemy.transform.position-transform.position);
				
				transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, Time.deltaTime * rotationSpeed);
            }
        }
        else
        {
            LastFired -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Fires a projectile and prevents refiring for time = (1 / FireRate).
    /// </summary>
    protected virtual void Fire(GameObject enemy)
    {
        // set cooldown
        LastFired = Time.time;
        // create projectile from Projectile prefab attached
		Vector3 spawnPos = transform.position;

		if (projectileSource != null) {
			spawnPos = projectileSource.position;		
		}

		GameObject projectile = Instantiate(ProjectileType, spawnPos+Vector3.up, ProjectileType.transform.rotation) as GameObject;


        // set its target
		projectile.GetComponentInChildren<Projectile> ().Target = enemy;
    }

	public int GetCost(){
		return cost;
	}
    
}