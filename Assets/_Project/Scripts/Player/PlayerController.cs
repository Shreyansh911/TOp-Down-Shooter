using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed, turnSpeed;

    Rigidbody2D m_rb;

    float m_horizontalInput, m_verticalInput;

    Camera m_cam;
    Vector2 m_mouseWorldPos;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_cam = Camera.main;
    }

    void Update()
    {
        m_horizontalInput = Input.GetAxisRaw("Horizontal");
        m_verticalInput = Input.GetAxisRaw("Vertical");

        //Player Rotation
        m_mouseWorldPos = m_cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 viewDir = (m_mouseWorldPos - (Vector2)transform.position).normalized;
        transform.up = Vector2.Lerp(transform.up, viewDir, turnSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        m_rb.velocity = new Vector2(m_horizontalInput, m_verticalInput).normalized * moveSpeed;
    }
}
