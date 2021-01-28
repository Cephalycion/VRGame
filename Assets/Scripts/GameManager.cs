using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public TMPro.TextMeshProUGUI scoreDisplay;
	public GameObject reset;
	private int score = 0;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Debug.Log("Mutliple GameManager instance.");
			return;
		}
	}

	public void addScore()
	{
		++score;
		scoreDisplay.text = score.ToString() + "/7";

		if (score == 7)
		{
			reset.SetActive(true);
		}
	}
}
