using UnityEngine;


public class StripScroller : MonoBehaviour
{
    private Rigidbody2D rb2d;



    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();

        //Start the object moving.
        if(gameObject.tag == "background")
            rb2d.velocity = new Vector2(0, -1f);
        if (gameObject.tag == "backgroundP")
            rb2d.velocity = new Vector2(0, -15f);
    }

    void Update()
    {
        /*// If the game is over, stop scrolling.
        if (GameState.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }*/
    }
}
