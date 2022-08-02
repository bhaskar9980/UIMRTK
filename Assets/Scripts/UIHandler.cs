using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameObj;

    [Serializable]
    public struct MeshScalePair
    {
        public Mesh mesh;
        public Vector3 scale;
    }

    public List<MeshScalePair> MeshScaleList = new();

    public void ToggleObject(GameObject gameObjectToToggle)
    {
        gameObjectToToggle.SetActive(!gameObjectToToggle.activeSelf);
    }

    public void SwitchMesh(int MeshScalePairIndex)
    {
        Mesh newMesh = MeshScaleList[MeshScalePairIndex].mesh;
        gameObj.GetComponent<MeshFilter>().mesh = newMesh;
        gameObj.transform.localScale = MeshScaleList[MeshScalePairIndex].scale;

        BoxCollider boxCollider = gameObj.GetComponent<BoxCollider>();
        boxCollider.size = newMesh.bounds.size;
        boxCollider.center = newMesh.bounds.center;

        gameObj.GetComponent<BoundsControl>().UpdateBounds();
    }

    public void ModifySize(SliderEventData data)
    {
        gameObj.transform.localScale = new Vector3(data.NewValue, data.NewValue, data.NewValue);
    }
}