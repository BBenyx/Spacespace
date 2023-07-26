using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] float thrustSpeed = 1000f;
    [SerializeField] float rotationSpeed = 300f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    void ProcessThrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        }
        else
        {
            audioSource.Stop();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
        }
    }


    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // gravitácó forgatásának letiltása, hogy ne zavarjon be az irányításba
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
