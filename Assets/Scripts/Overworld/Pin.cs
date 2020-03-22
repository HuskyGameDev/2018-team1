using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Direction
{
	Up,
	Down,
	Left,
	Right
}

public class Pin : MonoBehaviour
{
	[Header("Options")] //
	public bool IsAutomatic;
	public bool HideIcon;
	public string SceneToLoad;
	public string LevelName;

	[Header("Unlocked")]
	public bool unlocked;
	public int key;
	
	[Header("Pins")] //
	public Pin UpPin;
	public Pin DownPin;
	public Pin LeftPin;
	public Pin RightPin;

	private Dictionary<Direction, Pin> _pinDirections; 

	private LineRenderer lineUp;
	private LineRenderer lineRight;
	private LineRenderer lineDown;
	private LineRenderer lineLeft;
	
	
	/// <summary>
	/// Use this for initialisation
	/// </summary>
	private void Start()
	{
		// Load the directions into a dictionary for easy access
		_pinDirections = new Dictionary<Direction, Pin>
		{
			{ Direction.Up, UpPin },
			{ Direction.Down, DownPin },
			{ Direction.Left, LeftPin },
			{ Direction.Right, RightPin }
		};
		
		Char[] space = {' '};
		String[] split = gameObject.name.Split(space);
		bool disableMe = false;

		switch ( split[0].Substring(1,1) )
		{
			case "1":
				disableMe = ((PersistentData.World1Levels & convertToLevelID(split[0].Substring(3))) != 0);
				break;
			case "2":
				disableMe = ((PersistentData.World2Levels & convertToLevelID(split[0].Substring(3))) != 0);
				break;
			case "3":
				disableMe = ((PersistentData.World3Levels & convertToLevelID(split[0].Substring(3))) != 0);
				break;
			case "4":
				disableMe = ((PersistentData.World4Levels & convertToLevelID(split[0].Substring(3))) != 0);
				break;
			default:
				break;
		}
		Transform[] allChildren = GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren)
		{
			if ( child.gameObject.name == "RedX" && disableMe)
			{
				child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
			}
		}

		unlocked = ((PersistentData.UnlockData & key) != 0);
	}

	private static int convertToLevelID(string value)
    {
        if ( value == "F" || value == "F1")
        {
            return 256;
        }
        else if ( value == "F2" )
        {
            return 512;
        }
        int result = 0;
        for (int i = 0; i < value.Length; i++)
        {
            char letter = value[i];
            result = 10 * result + (letter - 48);
        }
        return (int)Math.Pow(2, result);
    }
	
	/// <summary>
	/// Get the pin in a selected direction
	/// Using a switch statement rather than linq so this can run in the editor
	/// </summary>
	/// <param name="direction"></param>
	/// <returns></returns>
	public Pin GetPinInDirection(Direction direction)
	{
		switch (direction)
		{
			case Direction.Up:
			{
				if( UpPin != null && UpPin.unlocked )
				{
					return UpPin;
				}
				else
				{
					return null;
				}
			}
			case Direction.Down:
			{
				if( DownPin != null && DownPin.unlocked )
				{
					return DownPin;
				}
				else
				{
					return null;
				}
			}
			case Direction.Left:
			{
				if( LeftPin != null && LeftPin.unlocked )
				{
					return LeftPin;
				}
				else
				{
					return null;
				}
			}
			case Direction.Right:
			{
				if( RightPin != null && RightPin.unlocked )
				{
					return RightPin;
				}
				else
				{
					return null;
				}
			}
			default:
				throw new ArgumentOutOfRangeException("direction", direction, null);
		}
	}

	
	/// <summary>
	/// This gets the first pin thats not the one passed 
	/// </summary>
	/// <param name="pin"></param>
	/// <returns></returns>
	public Pin GetNextPin(Pin pin)
	{
		return _pinDirections.FirstOrDefault(x => x.Value != null && x.Value != pin).Value;
	}
	
	
	/// <summary>
	/// Draw lines between connected pins
	/// </summary>
	private void OnDrawGizmos()
	{
		if(UpPin != null) DrawLine(UpPin);
		if(RightPin != null) DrawLine(RightPin);
		if(DownPin != null) DrawLine(DownPin);
		if(LeftPin != null) DrawLine(LeftPin);
	}


	/// <summary>
	/// Draw one pin line
	/// </summary>
	/// <param name="pin"></param>
	protected void DrawLine(Pin pin)
	{   
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, pin.transform.position);
	}

	public Pin toPin(String lvlName)
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("pin collection");
		foreach(GameObject p in objs)
		{
			//Debug.Log("Pins: " + p);
			foreach (Transform child in p.transform)
			{
				//Debug.Log("Child (individual pin): " + child);
				Pin ret = child.gameObject.GetComponent("Pin") as Pin;
				//Debug.Log("pin? " + ret);
				if (ret.LevelName == lvlName)
				{
					return ret;
				}
			}
		}
		return this;
	}

}
