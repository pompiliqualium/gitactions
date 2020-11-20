using UnityEngine;
public class Player : MonoBehaviour
{
    public PowerBar powerBar;
    public Bone bone;
    public Rigidbody Rigidbody;
    public SphereCollider Collider;

    [SerializeField]
    private float speed;

    private bool isPositionChosen = false;
    private bool isThrowPowerChosen = false;

    private Vector3 direction;


    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        direction = transform.right;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (isPositionChosen)
            {
                SetThrowPower();
            }
            else SetThrowPosition();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            var previousVelocity = Rigidbody.velocity;
            var velocity = new Vector3(-previousVelocity.x, previousVelocity.y, previousVelocity.z);

            direction = SwappedDirection();

            StopMovement();

            Rigidbody.AddForce(direction * speed, ForceMode.Acceleration);

        }
    }


    public void ThrowBone(float power)
    {
        Debug.Log(bone.weight);
    }

    public void SetThrowPower()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!powerBar.isAnimated)
                powerBar.Show();
            else
                ThrowBone(powerBar.GetPowerAndHide());
        }
    }

    public void SetThrowPosition()
    {
        Rigidbody.AddForce(transform.right * speed, ForceMode.Acceleration);
        if (Input.GetButtonDown("Fire1"))
        {
            StopMovement();
            isPositionChosen = true;
        }
    }
    private void StopMovement()
    {
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.angularVelocity = Vector3.zero;
    }

    private Vector3 SwappedDirection()
    {
        var swapeddirection = direction == transform.right
        ? -transform.right
        : transform.right;

        return swapeddirection;
    }

}
