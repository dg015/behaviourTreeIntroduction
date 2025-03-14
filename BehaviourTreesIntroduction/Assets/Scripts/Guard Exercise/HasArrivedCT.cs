using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Conditions {

	public class HasArrivedCT : ConditionTask
	{
		public BBParameter<Transform> CurrentDestination;
		public BBParameter<Transform> Point1;
		public BBParameter<Transform> Point2;
		public BBParameter<NavMeshAgent> NavAgent;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable()
		{

		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable()
		{

		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck()
		{
			if (HasDestination() == true)
			{
				if (CurrentDestination.value.position == Point1.value.position)
				{
					Debug.Log("down here");
					CurrentDestination.value = Point2.value;
					
					return true;
				}
				else
				{
					CurrentDestination.value = Point1.value;
					return true;
				}
			}
			else
			{
				return false;
			}
		}

		private bool HasDestination()
		{
			if (CurrentDestination.value == null)
			{
				CurrentDestination.value = Point1.value;
				return true;

			}
			else
			{
				Debug.Log("Already got location");
				return true;
			}

		}
	}
}