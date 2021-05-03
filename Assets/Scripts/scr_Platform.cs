using UnityEngine;

public class scr_Platform : MonoBehaviour
{
// Transforms to act as start and end markers for the journey.
public Transform startMarker;
public Transform endMarker;
public float startTime;
public float speed;
public float sDistance;
public float eDistance;

private Vector3 currentPos;
private Rigidbody rb;
[SerializeField]
CharacterController cc;


void Start()
     {
          rb = GetComponent<Rigidbody>();
     }

// Follows the target position like with a spring
void FixedUpdate()
     {
     currentPos = Vector3.Lerp(startMarker.position, endMarker.position, Mathf.Cos(Time.time / startTime * Mathf.PI * speed) * sDistance * eDistance);
     rb.MovePosition(currentPos);
     }
     private void OnTriggerEnter (Collider other)
     {
         if (other.tag == "Player")
         {
             Debug.Log("working");
             cc = other.GetComponent<CharacterController>();
         }
     }
     private void OnTriggerStay (Collider other)
     {
         if (other.tag == "Player")
         {
             cc.Move(rb.velocity * Time.deltaTime);
         }
     }
}
