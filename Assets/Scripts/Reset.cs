using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
	public float countTimer = 5.0f;
	public TMPro.TextMeshProUGUI text;

	private bool once = true;

    // Update is called once per frame
    void Update()
    {
		if (countTimer > 0.0f)
		{
			countTimer -= Time.deltaTime;
			text.text = "RESET IN: " + countTimer.ToString("0");
		}
		else if (once)
		{
			once = false;
			SceneManager.LoadScene("VRGame");
		}
    }
}
