using UnityEngine;
using System.Collections;

[System.Serializable]
public class DataHolder
{
	public float someFloat;
	public int someInt;
	public Animator someAnimator;
	public Vector3 someVector3;
	public Color someColor;
	public SomeEnum someEnum;
}

public enum SomeEnum
{
	Test0,
	Test1,
	Test2
}
