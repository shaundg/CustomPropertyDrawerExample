using UnityEngine;
using System.Collections;

public class DemoClass : MonoBehaviour
{
	public float justFloatData;
	public int justIntData;
	public Vector3 justVector3;
	public Animator justAnimator;
	public JustEnum justEnum;
	
	public DataHolder someDemoClassNonMonoBehaviour = new DataHolder();

	void Update()
	{
	}
}


public enum JustEnum
{
	Just0,
	Just1,
	Just2
}


