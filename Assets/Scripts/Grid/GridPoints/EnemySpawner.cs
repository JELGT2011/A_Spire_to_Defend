using UnityEngine;
using System.Collections;

public class EnemySpawner : GridPoint {
	public EnemyWave[] enemyWaves;
	private int currentWaveIndex = 0;
	private int currentEnemyIndex = 0;
	public float initialCooldown = 3.0f;//Time to wait till we start

	private float currTimer;

	private enum State {SPAWNING, WAITING_BETWEEN_ENEMIES, WAITING_BETWEEN_SPAWNS, DONE};
	private State currState;

	public GridPoint enemyGoal;

	void Update(){
		if (initialCooldown > 0) {
			initialCooldown-=Time.deltaTime;
			currState = State.SPAWNING;
		}
		else{
			//Yeah I know, but its fastest
			switch(currState){
				case State.SPAWNING:
				SpawnEnemy();
				break;
				case State.DONE:
				break;
			case State.WAITING_BETWEEN_ENEMIES:
			case State.WAITING_BETWEEN_SPAWNS:
				if(currTimer>0){
					currTimer-=Time.deltaTime;
				}
				else{
					currState = State.SPAWNING;
				}
				break;
			}
		}
	}

	public bool IsDone(){
		return currState.Equals (State.DONE);
	}

	void SpawnEnemy(){
		GameObject enemy = (GameObject)(Instantiate ((enemyWaves [currentWaveIndex].enemyList [currentEnemyIndex]).gameObject) as GameObject);
		Enemy realEnemy = (enemy).GetComponent<Enemy> ();

		Global.Instance.AddEnemy (realEnemy);
		realEnemy.Initialize (this, enemyGoal);


		currentEnemyIndex++;
		currState = State.WAITING_BETWEEN_ENEMIES;

		if (enemyWaves [currentWaveIndex].enemyList.Length <= currentEnemyIndex) {
			currentWaveIndex++;
			currentEnemyIndex=0;
			currState = State.WAITING_BETWEEN_SPAWNS;
			if(enemyWaves.Length<=currentWaveIndex){
				currState = State.DONE;
			}
			else{
				currTimer=enemyWaves[currentWaveIndex].waveCoolDown;
			}
		}
		else{
			currTimer=enemyWaves[currentWaveIndex].spawnCoolDown;
		}
	}


}
