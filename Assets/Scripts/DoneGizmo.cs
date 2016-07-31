using UnityEngine;
using System.Collections;

public class DoneGizmo : MonoBehaviour
{

	void OnDrawGizmos ()
	{
		// Draw Gizmos curve
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position,1);
	}
}
