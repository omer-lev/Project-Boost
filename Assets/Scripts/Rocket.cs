using UnityEngine;
using UnityEngine.SceneManagement;


public class Rocket : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 200;
    [SerializeField] float boostSpeed = 150f;

    Rigidbody rb;
    AudioSource boostSound;

    enum State { Alive, Dying, Transcening };
    State state = State.Alive;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boostSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Boost();
    }


    private void Boost()
    {
        // BOOST
        if (Input.GetKey(KeyCode.Space) && state == State.Alive)
        {
            rb.AddRelativeForce(Vector3.up * boostSpeed * Time.deltaTime);
            if (!boostSound.isPlaying)
            {
                boostSound.Play();
            }
        }
        else
        {
            boostSound.Stop();
        }
    }


    private void Rotate()
    {
        // ROTATION
         rb.freezeRotation = true;

        if (state == State.Alive)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            }

            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
            }
        }

        rb.freezeRotation = false;
    }


    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":

                break;

            case "Fuel":

                break;

            case "Finish":
                state = State.Transcening;
                Invoke("LoadNextScene", 1f);
                break;

            default:
                state = State.Dying;
                Invoke("LoadFirstLevel", 1f);
                break;
        }
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}