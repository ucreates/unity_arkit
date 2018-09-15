﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEngine.XR.iOS {
public class EditorHitTest : MonoBehaviour {
    public Transform m_HitTransform;
    public float maxRayDistance = 30.0f;
    public LayerMask collisionLayerMask;
#if UNITY_EDITOR   //we will only use this script on the editor side, though there is nothing that would prevent it from working on device
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //we'll try to hit one of the plane collider gameobjects that were generated by the plugin
            //effectively similar to calling HitTest with ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent
            if (Physics.Raycast(ray, out hit, maxRayDistance, collisionLayerMask)) {
                //we're going to get the position from the contact point
                m_HitTransform.position = hit.point;
                Debug.Log(string.Format("x:{0:0.######} y:{1:0.######} z:{2:0.######}", m_HitTransform.position.x, m_HitTransform.position.y, m_HitTransform.position.z));
                //and the rotation from the transform of the plane collider
                m_HitTransform.rotation = hit.transform.rotation;
            }
        }
    }
#endif
}
}