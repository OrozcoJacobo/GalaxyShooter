using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer m_Renderer;
    private float _animationSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        if(m_Renderer == null)
        {
            Debug.LogError("Mesh Renderer on Parallax in NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_Renderer.material.mainTextureOffset += new Vector2(0, _animationSpeed * Time.deltaTime);
    }
}
