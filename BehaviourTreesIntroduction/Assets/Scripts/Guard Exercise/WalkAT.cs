using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class WalkAT : ActionTask {

        public BBParameter<Transform> CurrentDestination;
        public BBParameter<NavMeshAgent> NavAgent;
        public BBParameter<Transform> Interruptor;


        public BBParameter<bool> hasBeenInterrupted;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			WalkToLocation();
			HasArrived();
		}
		private void WalkToLocation()
		{
			NavAgent.value.SetDestination(CurrentDestination.value.position);
		}
		private void HasArrived()
		{
			if(Vector3.Distance(agent.transform.position, CurrentDestination.value.position) < 5)
			{
				EndAction(true);
				Debug.Log("has arrived");
			}
			if(interrupted() == true)
			{
				Debug.Log("interrupted");
				EndAction(false);
			}
		}

		private bool interrupted()
		{
			if(Vector3.Distance(agent.transform.position,Interruptor.value.position) < 5)
			{
				Debug.Log("Im here");
				return true; 
			}	
			else
			{
				return false;
			}

		}

	}
}