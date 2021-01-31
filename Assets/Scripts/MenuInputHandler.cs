using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Stateless;

// This script will enable/disable given action maps depending on which state it is
public class MenuInputHandler : MonoBehaviour
{
    enum State
    {
        Start,
        Falling,
        Falling_Intro,
        Gamemode,
        Endscreen
    }

    enum Trigger
    {
        Menu_Start,
        Menu_StartGame
    }

    Stateless.StateMachine<State, Trigger> _state = new StateMachine<State, Trigger>(State.Start);

    [SerializeField] rho.Event _fallingEvent;
    [SerializeField] rho.Event _gameModeStartEvent;

    void Start()
    {
        _state.Configure(State.Start)
            .Permit(Trigger.Menu_Start, State.Falling);

        _state.Configure(State.Falling)
            .Ignore(Trigger.Menu_Start)
            .OnEntry(t => _fallingEvent.Raise())
            .Permit(Trigger.Menu_StartGame, State.Gamemode);

        _state.Configure(State.Gamemode)
            .Ignore(Trigger.Menu_Start)
            .Ignore(Trigger.Menu_StartGame)
            .OnEntry(t => _gameModeStartEvent.Raise());
    }

    public void OnMenu_Start()
    {
        _state.Fire(Trigger.Menu_Start);
    }

    public void OnMenu_StartGame()
    {
        _state.Fire(Trigger.Menu_StartGame);
    }
}
