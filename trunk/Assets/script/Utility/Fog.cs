using UnityEngine;
using System.Collections;

public class Fog : MonoBehaviour {

    public Mesh mesh;
    public Vector3[] vertices;
    public Color[] colors;

    public float radius;

    private Vector3 _fogCenter;

    // Use this for initialization
    void Start()
    {

        radius = 1.0f;

        mesh = GetComponent<MeshFilter>().mesh;

        vertices = mesh.vertices;
        colors = new Color[vertices.Length];

        if (gameObject.name == "Fow50")
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                colors[i] = Color.grey;
                colors[i].a = 1;
            }
        }

        if (gameObject.name == "Fow100")
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                colors[i] = Color.black;
                colors[i].a = 1;
            }
        }

        mesh.colors = colors;

        if (gameObject.name == "Fow50") {
            RefreshFog();
            //StartCoroutine(RefreshFog());
        }
    }

    public IEnumerator RefreshFog()
    {

        while (true)
        {
            Mesh mesh = GetComponent<MeshFilter>().mesh;
            vertices = mesh.vertices;
            Color[] colors = new Color[vertices.Length];

            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i].a <= 1)
                {
                    float f = colors[i].a;
                    f += 0.1f;
                    if (f > 1)
                        f = 1;
                    colors[i].a = f;
                }
            }

            mesh.colors = colors;
            yield return new WaitForSeconds(1);
        }

    }


    // Update is called once per frame
    void Update()
    {

        //Vector3 playerPos = Loop.CharacterManager.GetPlayerInstance().AttachedGameObject.transform.position;
        //_fogCenter = new Vector3(playerPos.x, playerPos.y, _fogCenter.z);
        //Vector3 relativePos = transform.InverseTransformPoint(_fogCenter);
        //if (gameObject.name == "Fow50")
        //    HalfMesh(mesh, relativePos, radius);
        //if (gameObject.name == "Fow100")
        //    FullMesh(mesh, relativePos, radius);


    }

    private void HalfMesh(Mesh mesh, Vector3 pos, float inRadius)
    {

        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        float sqrRadius = inRadius * inRadius;
        Color[] colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
        {
            float sqrMagnitude = (vertices[i] - pos).sqrMagnitude;
            if (sqrMagnitude > sqrRadius)
                continue;
            colors[i].a = 0;
        }
        mesh.colors = colors;
    }

    private void FullMesh(Mesh mesh, Vector3 pos, float inRadius)
    {

        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        float sqrRadius = inRadius * inRadius;

        for (int i = 0; i < vertices.Length; i++)
        {
            float sqrMagnitude = (vertices[i] - pos).sqrMagnitude;
            if (sqrMagnitude > sqrRadius)
                continue;
            colors[i].a = 0;
        }
        mesh.colors = colors;
    }

}
