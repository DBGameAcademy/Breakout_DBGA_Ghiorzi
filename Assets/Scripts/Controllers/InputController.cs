using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private Paddle paddle;

    private void Update()
    {
        if(GameController.Instance.IsPlaying && GameController.Instance.IsPaused)
        {
            if(Input.anyKeyDown && !Input.GetMouseButton(0))
            {
                GameController.Instance.UnpauseGame();
            }
        }
        else if(GameController.Instance.IsPlaying && !GameController.Instance.IsPaused)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                paddle.Accelerate();
            }
            else
            {
                paddle.Deaccelerate();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                paddle.Move(Vector2.left);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                paddle.Move(Vector2.right);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameController.Instance.PauseGame();
            }
        }
    }
}
