using UnityEngine;
using System.Collections;
/* Ranged enemy positioning script
 * Discription: calculates the offset from the player to the enemy and then normalizes the value and multiplies
 * it by the distance. 
 * CHANGELOG:
 * otto (03/03/24) - Added some conditions to try and keep it from getting stuck in the corners.
 *
 *
 */

namespace Pathfinding
{
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour
	{
		/// <summary>The object that the AI should move to</summary>
		public float rangeDistance = 5;
		public float sceneBoundX1 =-10;
		public float sceneBoundX2 =10;
		public float sceneBoundY1 = -5;
		public float sceneBoundY2 = 5;
		public Transform target;
		IAstarAI ai;

		void OnEnable()
		{
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable()
		{
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update()
		{

			Vector3 tempOffset = (transform.position - target.position);
			Vector3 newTarget = target.position + tempOffset.normalized * rangeDistance;
			if (newTarget.x < sceneBoundX1 || newTarget.x>sceneBoundX2) {
				tempOffset.x = tempOffset.y;
				newTarget = target.position + tempOffset.normalized * rangeDistance;
			}
			else if (newTarget.y < sceneBoundY1 || newTarget.y > sceneBoundY2)
			{
				tempOffset.y = tempOffset.x;
				newTarget = target.position + tempOffset.normalized * rangeDistance;
			}
				if (target != null && ai != null) ai.destination = newTarget;
		}
	}
}