//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
	public GameObject sphere;
	public GameObject player;

    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance, ~LayerMask.GetMask("Sphere")))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExit", SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter", SendMessageOptions.DontRequireReceiver);
            }

			if (hit.transform.gameObject.name == "Ground")
			{
				sphere.SetActive(true);
				sphere.transform.position = hit.point;
			}
			else
			{
				sphere.SetActive(false);
			}
		}
        else
        {
			// No GameObject detected in front of the camera.
			_gazedAtObject?.SendMessage("OnPointerExit", SendMessageOptions.DontRequireReceiver);
            _gazedAtObject = null;

			sphere.SetActive(false);
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
			pressed();
        }

#if UNITY_EDITOR
		if (Input.GetMouseButtonDown(0))
		{
			pressed();
		}
#endif
	}

	private void pressed()
	{
		if (sphere.activeInHierarchy)
		{
			Vector3 pos = new Vector3(sphere.transform.position.x, player.transform.position.y, sphere.transform.position.z);
			player.transform.position = pos;
		}
		_gazedAtObject?.SendMessage("OnPointerClick", SendMessageOptions.DontRequireReceiver);
	}
}
