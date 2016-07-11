using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 1.1f;
    private Rigidbody rb;
    private int counter;
    public Text countText;
    public Text winText;

    void Start() {
        rb = GetComponent<Rigidbody>();
        counter = 0;
        SetCountText();
        winText.text = "";
    }
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            counter++;
            SetCountText();
        }
        
    }

    void SetCountText() {
        countText.text = "Count: " + counter.ToString();
        if (counter == 8)
        {
            winText.text = "Winning";
        }
    }

}
