using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReTiler : MonoBehaviour
{
	public float scale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
		MeshRenderer[] renderers = gameObject.GetComponentsInChildren<MeshRenderer>();

		for (int i = 0; i < renderers.Length; ++i)
		{
			renderers[i].material.mainTextureScale = new Vector2(
				renderers[i].gameObject.transform.localScale.x / scale, 
				renderers[i].gameObject.transform.localScale.y / scale
				);
		}
    }
}
