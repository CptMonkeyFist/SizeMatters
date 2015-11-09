using UnityEngine;
using System.Collections;

namespace SizeMatters
{
    public class MeshNoCulling : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
            mesh.bounds = new Bounds(new Vector3(-Mathf.Infinity, -Mathf.Infinity, -Mathf.Infinity),
                new Vector3(-Mathf.Infinity, -Mathf.Infinity, -Mathf.Infinity));
        }
    }
}
