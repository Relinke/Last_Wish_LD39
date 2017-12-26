using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private static MoveCommand _moveCommand = new MoveCommand();
    private static JumpCommand _jumpCommand = new JumpCommand();
    private static AttackCommand _attackCommand = new AttackCommand();

    public static List<Command> HandleInput()
    {
        List<Command> commands = new List<Command>();
        float xAxis = Input.GetAxis("Horizontal");
        commands.Add(_moveCommand.Init(xAxis));
        if (Input.GetButtonDown("Fire1"))
        {
            commands.Add(_attackCommand);
        }
        if (Input.GetButtonDown("Jump"))
        {
            commands.Add(_jumpCommand);
        }
        return commands;
    }
}