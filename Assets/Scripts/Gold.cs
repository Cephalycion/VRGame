using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
	private bool activate = false;
	private float fA = 0.0f;

	private void Update()
	{
		if (activate)
		{
			fA += Time.deltaTime;
			Mathf.Clamp(fA, 0.0f, 1.0f);
			RadialBar.instance.fill.fillAmount = fA;

			if (fA >= 1.0f)
			{
				RadialBar.instance.fill.fillAmount = 0.0f;
				GameManager.instance.addScore();
				gameObject.SetActive(false);
			}
		}
	}

	public void OnPointerEnter()
	{
		activate = true;
	}

	public void OnPointerExit()
	{
		RadialBar.instance.fill.fillAmount = 0.0f;
		activate = false;
		fA = 0.0f;
	}
}
