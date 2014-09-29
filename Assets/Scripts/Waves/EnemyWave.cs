using UnityEngine;
using System.Collections;

[System.Serializable]
public class EnemyWave {
	public Enemy[] enemyList;
	public float waveCoolDown = 1.0f;//Cooldown after wave is dispersed
	public float spawnCoolDown = 0.2f; //Time between each enemy spawn

}
