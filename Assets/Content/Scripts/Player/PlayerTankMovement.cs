using UnityEngine;

public class PlayerTankMovement : MonoBehaviour
{
    private float playerInputX = 0;
    private float playerInputY = 0;

    [SerializeField] private float speed = 250;
    private Rigidbody2D rb;
    [SerializeField] Transform TankTracks;
    private float tracksRotZ;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerInputX = Input.GetAxisRaw("Horizontal");
        playerInputY = Input.GetAxisRaw("Vertical");
        //SwapSprite();
    }

    void SwapSprite()
    {
        if (playerInputX > 0)// Right
        {
            transform.localScale = new Vector3(
                Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }
        else if (playerInputX < 0)// Left
        {
            transform.localScale = new Vector3(
                -1 * Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }

        if (playerInputY > 0)// Up
        {
            transform.localScale = new Vector3(
                Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }
        else if (playerInputY < 0)// Down
        {
            transform.localScale = new Vector3(
                -1 * Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(
            playerInputX * speed * Time.fixedDeltaTime,
            playerInputY * speed * Time.fixedDeltaTime
        );

        if (playerInputY < 0)
            tracksRotZ = Mathf.MoveTowards(tracksRotZ, playerInputX * 35, 5);
        if (playerInputY >= 0)
            tracksRotZ = Mathf.MoveTowards(tracksRotZ, -playerInputX * 35, 5);

        tracksRotZ = Mathf.Clamp(tracksRotZ, -35, 35);
        TankTracks.localEulerAngles = new Vector3(0, 0, tracksRotZ);
    }
}