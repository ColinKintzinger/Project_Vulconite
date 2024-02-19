using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public float verticalInput;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.up *  verticalInput * Time.deltaTime * speed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            string doorIdentifier = collision.gameObject.GetComponent<DoorIdentifier>().identifier;

            switch (doorIdentifier)
            {
                case "Door1":
                    SceneManager.LoadScene("SampleScene");
                    break;
                case "Door2":
                    SceneManager.LoadScene("Mellee_testing_scene");
                    break;
                // Add more cases if more doors below
                default:
                    break;
            }
        }
    }

}
