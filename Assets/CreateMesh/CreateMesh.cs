using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateMesh
{
    /// <summary>
    /// 動的にメッシュを生成する
    /// </summary>
    public class CreateMesh : MonoBehaviour
    {
        [SerializeField] GameObject _meshPrefab;
        [SerializeField] Material _material;

        readonly float root3 = 1.732051f;

        void Start()
        {
            GameObject go = Instantiate(_meshPrefab);
            Mesh mesh = new Mesh();
            Vector3[] pos = new Vector3[]
            {
                // 上
                new Vector3(0, 1, 0),
                new Vector3(1, 1, -root3),
                new Vector3(-1, 1, -root3),
                // 下
                new Vector3(0, 0, 0),
                new Vector3(-1, 0, -root3),
                new Vector3(1, 0, -root3),
            };
            int[] vertIndices = new int[]
            {
                0, 1, 2,
                3, 4, 5,
                0, 2, 4,
                4, 3, 0,
                2, 1, 5,
                5, 4, 2,
                1, 0, 3,
                3, 5, 1,
            };

            Vector3[] vertices = new Vector3[vertIndices.Length];
            for (int i = 0; i < vertIndices.Length; i++)
            {
                vertices[i] = pos[vertIndices[i]];
            }
            mesh.vertices = vertices;

            int[] triangles = new int[mesh.vertices.Length];
            for (int i = 0; i < mesh.vertices.Length; i++)
            {
                triangles[i] = i;
            }
            mesh.triangles = triangles;

            mesh.RecalculateNormals();

            MeshFilter filter = go.GetComponent<MeshFilter>();
            filter.sharedMesh = mesh;

            var renderer = go.GetComponent<MeshRenderer>();
            renderer.material = _material;
        }

        void Update()
        {

        }
    }
}
