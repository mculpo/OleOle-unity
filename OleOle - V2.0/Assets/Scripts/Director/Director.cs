using UnityEngine;
using System.Collections;

public class Director : AudioController {

	public static SystemGameState GAME_STATE = SystemGameState.Stopped;

#region events
	public static event System.Action<bool> onPauseEvent;
	public static event System.Action onGameOverEvent;
	public static event System.Action onStartGameEvent;
#endregion

	private static Director self;

	public static bool pause;

	protected override void Start () {

		base.Start();

		self = this;

		startGame();

	}
	
	private static void startGame()
	{
		TouchController.layerMask = LayerMask.NameToLayer("Default");

		pause = false;

		GAME_STATE = SystemGameState.Running;

		//onStartGameEvent();

	}

	public static void gameOver(){

		GAME_STATE = SystemGameState.Stopped;

		onGameOverEvent();
		
	}

	public static void pauseGame(){

		if(GAME_STATE != SystemGameState.Stopped){

			pause = !pause;

			if(pause){

				GAME_STATE = SystemGameState.Paused;

			}
			else{

				GAME_STATE = SystemGameState.Running;

			}

			onPauseEvent(pause);

		}
		
	}

	public static void loadLevel(int level){

		Application.LoadLevel(level);

	}

	public static Director Get {
		get {
			return self;
		}
	}

}