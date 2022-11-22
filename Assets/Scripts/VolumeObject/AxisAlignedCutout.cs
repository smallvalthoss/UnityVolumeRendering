using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityVolumeRendering
{
    public class AxisAlignedCutout : MonoBehaviour, CrossSectionObject
    {

        [SerializeField]
        private VolumeRenderedObject targetObject;

        [SerializeField, HideInInspector]
        private Vector3 ClipDimMin;

        [SerializeField, HideInInspector]
        private Vector3 ClipDimMax;

        // Functions for setting the min and max clipping values for each axis.
        // These functions 
        public void SetAxisClipMin(Vector3 min)
        {
            ClipDimMin = new Vector3(Mathf.Clamp(min.x, 0, 1), Mathf.Clamp(min.y, 0, 1), Mathf.Clamp(min.z, 0, 1));
        }

        public void SetAxisClipMax(Vector3 max)
        {
            ClipDimMax = new Vector3(Mathf.Clamp(max.x, 0, 1), Mathf.Clamp(max.y, 0, 1), Mathf.Clamp(max.z, 0, 1));
        }

        // for speed when calling every frame in VR? VR be expensive
        public void SetDim1Min(float min1) { ClipDimMin.x = Mathf.Clamp(min1, 0, 1); }
        public void SetDim2Min(float min2) { ClipDimMin.y = Mathf.Clamp(min2, 0, 1); }
        public void SetDim3Min(float min3) { ClipDimMin.z = Mathf.Clamp(min3, 0, 1); }

        public void SetDim1Max(float max1) { ClipDimMax.x = Mathf.Clamp(max1, 0, 1); }
        public void SetDim2Max(float max2) { ClipDimMax.y = Mathf.Clamp(max2, 0, 1); }
        public void SetDim3Max(float max3) { ClipDimMax.z = Mathf.Clamp(max3, 0, 1); }

        // Functions from CrossSectionObject interface
        public CrossSectionType GetCrossSectionType()
        {
            return CrossSectionType.BoxInclusive;
        }

        // Calculate matrix of box based on min/max clipping values (centre = (min+max)/2, scale = max-min)

        public Matrix4x4 GetMatrix()
        {
            return Matrix4x4.TRS(transform.position, transform.rotation, ClipDimMax - ClipDimMin);
        }
    }
}
