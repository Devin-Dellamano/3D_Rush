using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementTest : MonoBehaviour
{
	//[SerializeField] Transform target;
	//public float speed = 6f;
	//Vector3 targetPos;

	public List<LayerMask> whatCanBeClickedOn;
	private NavMeshAgent myAgent;

	public NavigationBaker navMeshBuilder;

	// Start is called before the first frame update
	void Start()
	{
		myAgent = this.GetComponent<NavMeshAgent>();
		//targetPos = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100, whatCanBeClickedOn[0]) ||
				Physics.Raycast(ray, out hit, 100, whatCanBeClickedOn[1]))
			{
				myAgent.SetDestination(hit.point);
				hit.collider.gameObject.SetActive(false);
				navMeshBuilder.Rebake();
			}
		}
		//{
		//	RaycastHit hit;
		//	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//	if (Physics.Raycast(ray, out hit))
		//	{
		//		if (hit.collider.name == "BreakableWall" || hit.collider.name == "Door")
		//		{
		//			targetPos = hit.point;
		//			targetPos.y = transform.position.y; 
		//		}
		//	}
		//}
		//if(transform.position != targetPos)
		//{
		//	transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
		//}
	}
}
