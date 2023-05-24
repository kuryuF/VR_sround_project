
using UnityEngine;

public class MovePos : MonoBehaviour
{
    private Vector3 mouse;
    private Vector3 target;



    private void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 10));
        target.y = transform.position.y;
        this.transform.position = target;

        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, 0f, 0.1f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, 0f, -0.1f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f, 0f, 0f);
        }*/

    }
}
