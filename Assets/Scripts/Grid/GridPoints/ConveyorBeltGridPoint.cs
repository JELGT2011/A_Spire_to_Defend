using UnityEngine;
using System.Collections;

public class ConveyorBeltGridPoint : GridPoint {

	private Color _oldColor;

	//We will change enemy's direction to up, down, or right depending on the type of tile
	public enum Direction {Right, Up, Down};
	public Direction newDirection;
	
	public float newSpeed = 0.1f;

	public override GridPoint ArriveAtGridpoint (Enemy enemy)
	{
		if(enemy != null)
		{
			if(newDirection == Direction.Up)
			{
				//TODO: Figure out how to rotate the enemy up
				//TODO: set the Tile''s material to the appropriate material

				Vector3 newPosition = (Vector3.up) - enemy.transform.position;
				Quaternion neededRotation = Quaternion.LookRotation(newPosition);
				enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, neededRotation,Time.deltaTime*enemy.rotationSpeed*4);
				
			}
			else if(newDirection == Direction.Down)
			{
				//TODO: Figure out how to rotate the enemy Down
				Vector3 newPosition = (Vector3.back) - enemy.transform.position;
				Quaternion neededRotation = Quaternion.LookRotation(newPosition);
				enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, neededRotation,Time.deltaTime*enemy.rotationSpeed*4);
			}
			else if(newDirection == Direction.Right)
			{
				//TODO: Figure out how to rotate the enemy Right
				
				Vector3 newPosition = (Vector3.right) - enemy.transform.position;
				Quaternion neededRotation = Quaternion.LookRotation(newPosition);
				enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, neededRotation,Time.deltaTime*enemy.rotationSpeed*4);
			}


		}
		return this;
	}

	//Returns the new direction which the enemy should be rotated to
	public Direction getDirection()
	{
		return newDirection;
	}
}
