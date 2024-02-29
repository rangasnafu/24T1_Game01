using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public virtual bool CanInteract()
	{
		return false;
	}

	public virtual void Enter()
	{

	}

	public virtual void Exit()
	{

	}

	public virtual void Activate()
	{

	}

	public virtual void Deactivate()
	{

	}
}
