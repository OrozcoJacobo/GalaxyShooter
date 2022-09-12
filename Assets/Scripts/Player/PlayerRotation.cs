using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private float _playerRotationSpeed;
    [SerializeField]
    private Camera sceneCamera;
    private Rigidbody2D rb;
    private Vector2 mousePosition;
    private Fire fireLaser;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        fireLaser = GetComponentInChildren<Fire>();
        if(rb == null)
        {
            Debug.LogError("Rigidbody 2D is NULL in PlayerRotation");
        }
        if (fireLaser == null)
        {
            Debug.LogError("Fire is NULL in PlayerRotation");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Rotate();
    }

    void ProcessInputs()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void Rotate()
    {
        //Rotate player to follow mouse
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}
