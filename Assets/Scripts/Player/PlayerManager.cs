using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    PlayerMoveController playerMoveController = null;

    [SerializeField]
    PlayerCollisionController playerCollisionController = null;

    [SerializeField]
    PlayerStateController playerStateController = null;

    [SerializeField]
    PlayerAudioController playerAudioController = null;

    [SerializeField]
    PlayerAnimationController playerAnimationController = null;

    bool canMarioMove = true;

    void OnEnable()
    {
        playerMoveController.SetMarioIdle();
        playerAnimationController.PlayMarioIdleAnimation();
    }

    private void Start()
    {
        playerCollisionController.MarioHitGround += HandleMarioHitGround;

        // playerCollisionController.MarioGotHitByEnemy +=
        //     HandleMarioGotHitByEnemy;
        playerCollisionController.MarioIsCollidingWithObject +=
            HandleMarioCollidingWithObject;

        // EventManager.JumpedOnFlagEvent += HandleMarioJumpedOnFlag;
        // EventManger.FinishedLevelEvent += HandleMarioFinishedLevel;
        EventManager.MoveUpClicked += HandleMarioMoveUp;
        EventManager.MoveDownClicked += HandleMarioMoveDown;
        EventManager.MoveRightClicked += HandleMarioMoveRight;
        EventManager.MoveLeftClicked += HandleMarioMoveLeft;
        EventManager.AButtonClicked += HandleMarioMoveUp;
    }

    private void OnDestroy()
    {
        playerCollisionController.MarioHitGround -= HandleMarioHitGround;

        // playerCollisionController.MarioGotHitByEnemy -=
        // HandleMarioGotHitByEnemy;
        playerCollisionController.MarioIsCollidingWithObject -=
            HandleMarioCollidingWithObject;

        // EventManager.JumpedOnFlagEvent -= HandleMarioJumpedOnFlag;
        // EventManger.FinishedLevelEvent -= HandleMarioFinishedLevel;
        EventManager.MoveUpClicked -= HandleMarioMoveUp;
        EventManager.MoveDownClicked -= HandleMarioMoveDown;
        EventManager.MoveRightClicked -= HandleMarioMoveRight;
        EventManager.MoveLeftClicked -= HandleMarioMoveLeft;
        EventManager.AButtonClicked -= HandleMarioMoveUp;
    }

    void Update()
    {
        if (!canMarioMove)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)
        )
        {
            HandleMarioMoveUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            HandleMarioMoveDown();
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerMoveController.SetMarioStompingValue(false);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HandleMarioMoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HandleMarioMoveRight();
        }
        else
        {
            if (playerMoveController.IsMarioMoving())
            {
                Invoke("HandleMarioIdle", 1.0f);
            }
        }
    }

    private void HandleMarioJump()
    {
        playerAudioController.PlayJumpSound();
        playerMoveController.AddForceUp(300);
        playerMoveController.SetMarioJumpingValue(true);
        playerAnimationController.PlayMarioJumpAnimation();
    }

    private void HandleMarioStomp()
    {
        if (playerMoveController.IsMarioJumping())
        {
            playerMoveController.AddForceDown(300);
            playerMoveController.SetMarioStompingValue(true);
            playerAnimationController.PlayMarioStompAnimation();
        }
    }

    private void HandleMarioRunRight()
    {
        playerMoveController.AddForceRight(5);
        playerMoveController.TurnMarioRight();
        playerMoveController.SetMarioMovingValue(true);
        playerAnimationController.PlayMarioRunAnimation();
    }

    private void HandleMarioRunLeft()
    {
        playerMoveController.AddForceLeft(5);
        playerMoveController.TurnMarioLeft();
        playerMoveController.SetMarioMovingValue(true);
        playerAnimationController.PlayMarioRunAnimation();
    }

    private void HandleMarioSwimUp()
    {
        playerMoveController.AddForceUp(15);
        playerAnimationController.PlayMarioSwimAnimation();
    }

    private void HandleMarioSwimDown()
    {
        if (GameState.IsWaterLevel)
        {
            playerMoveController.AddForceDown(15);
            playerAnimationController.PlayMarioSwimAnimation();
        }
    }

    private void HandleMarioSwimRight()
    {
        playerMoveController.AddForceRight(2);
        playerMoveController.TurnMarioRight();
        playerMoveController.SetMarioMovingValue(true);
        playerAnimationController.PlayMarioSwimAnimation();
    }

    private void HandleMarioSwimLeft()
    {
        playerMoveController.AddForceLeft(2);
        playerMoveController.TurnMarioLeft();
        playerMoveController.SetMarioMovingValue(true);
        playerAnimationController.PlayMarioSwimAnimation();
    }

    private void HandleMarioMoveUp()
    {
        if (GameState.IsWaterLevel)
        {
            HandleMarioSwimUp();
        }
        else
        {
            HandleMarioJump();
        }
    }

    private void HandleMarioMoveDown()
    {
        if (GameState.IsWaterLevel)
        {
            HandleMarioSwimDown();
        }
        else
        {
            HandleMarioStomp();
        }
    }

    private void HandleMarioMoveRight()
    {
        if (GameState.IsWaterLevel)
        {
            HandleMarioSwimRight();
        }
        else
        {
            HandleMarioRunRight();
        }

        GameState.IsMarioFacingRight = true;
    }

    private void HandleMarioMoveLeft()
    {
        if (GameState.IsWaterLevel)
        {
            HandleMarioSwimLeft();
        }
        else
        {
            HandleMarioRunLeft();
        }
        GameState.IsMarioFacingRight = false;
    }

    private void HandleMarioIdle()
    {
        playerMoveController.SetMarioIdle();
        if (!GameState.IsWaterLevel)
        {
            playerAnimationController.PlayMarioIdleAnimation();
        }
    }

    public void HandleStartMarioStomp()
    {
        HandleMarioStomp();
    }

    public void HandleEndMarioStomp()
    {
        HandleMarioIdle();
        playerMoveController.SetMarioStompingValue(false);
    }

    private void HandleMarioHitGround()
    {
        playerMoveController.SetMarioJumpingValue(false);
    }

    private void HandleMarioCollidingWithObject(Collision2D collision)
    {
        if (playerMoveController.IsMarioStomping())
        {
            collision.gameObject.transform.parent.SendMessage("Break");
            collision.gameObject.SendMessage("Break");
        }
    }
}
