using UnityEngine;
using System.Collections;

public class ConveyorBeltGridPoint : GridPoint {

	private Color _oldColor;

	public enum Direction {Left, Right, Up, Down};
	public Direction newDirection;
	
	public float newSpeed = 0.1f;

	public override GridPoint ArriveAtGridpoint (Enemy enemy)
	{
		if(enemy != null)
		{
			if(newDirection == Direction.Up)
			{
				//TODO: Figure out how to rotate the enemy up
				//TODO: Set the material to the appropriate material
				//this.renderer.material = abalksdjfajksdfa;
			}
			else if(newDirection == Direction.Down)
			{
				//TODO: Figure out how to rotate the enemy Down

			}
			else if(newDirection == Direction.Left)
			{
				//TODO: Figure out how to rotate the enemy Left

			}
			else if(newDirection == Direction.Right)
			{
				//TODO: Figure out how to rotate the enemy Right

			}

			enemy.CurrentSpeed+= newSpeed;
		}
		return this;
	}

	//Returns the new direction which the enemy should be rotated to
	public Direction getDirection()
	{
		return newDirection;
	}
}
