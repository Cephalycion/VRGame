using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialBar : MonoBehaviour
{
	public static RadialBar instance = null;
	public Image fill;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Debug.Log("Multiple RadialBar instance");
			return;
		}
	}
}
