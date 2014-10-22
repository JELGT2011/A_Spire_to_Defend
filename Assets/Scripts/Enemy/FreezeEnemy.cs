using UnityEngine;
using System.Collections;

public class FreezeEnemy : Enemy {

	protected override void EnemyUpdate (){
		if(path!=null && path.Length>0){
			Vector3 differenceToGoal = (path[pathIndex].transform.position+Vector3.up) - transform.position;
			
			if (differenceToGoal.magnitude < MIN_DIST) {
				
				if(path.Length<=pathIndex+1){
					IsAlive =false;
					
					//TODO; hurt the player	
				}
				else{
					pathIndex++;
					
					GridPoint grid = path[pathIndex].ArriveAtGridpoint(this);
					
					if(grid==null){
						
						if(Grid.Instance.GetGridPoint(path[pathIndex]).CanPassThough()){
							//Freezing Logic
							for(int i =-40; i<50; i++){
								for(int j =-40; j<50; j++){
									GridPoint pnt = Grid.Instance.GetGridPoint(transform.position.x+i,transform.position.z+j);
									if(pnt!=null ){
										Tower tower = pnt.GetTower();

										if(tower!=null && tower.gameObject.GetComponent<FreezeEffect>()==null){
											tower.gameObject.AddComponent<FreezeEffect>();
										}
									}
								}
							}

						}
						else{
							path = AStar.Path(path[pathIndex-1],Target);
						}
					}
					else{
						path = AStar.Path(grid,Target);
					}
				}
				
			}
			else{
				transform.position+=differenceToGoal.normalized*CurrentSpeed*Time.deltaTime;
				
				//TODO; smooth look at
			}
		}
		
		
		if (!IsAlive){
			Global.Instance.RemoveEnemy(this);
			Destroy(transform.root.gameObject);
		}
	}
}
