using UnityEngine;
using System.Collections;

public class TeleporterGridPoint : GridPoint {
	public GridPoint goal;

	private Color inUse = Color.magenta;
	private Color _oldColor;

	public float rechargeTime = 1.0f;
	private float timer;

	void Start(){
		goal.renderer.material.color = inUse;
	}

	void Update(){
		if (timer > 0) {
			timer-=Time.deltaTime;
			renderer.material.color = Color.Lerp(_oldColor,inUse,timer/rechargeTime);

			if(timer<=0){
				renderer.material.color = _oldColor;
			}
		}
	}

	public override GridPoint ArriveAtGridpoint (Enemy enemy)
	{
		enemy.transform.position = goal.transform.position + Vector3.up;
		_oldColor = renderer.material.color;
		renderer.material.color = inUse;
		timer = rechargeTime;

		return goal;
	}
}
