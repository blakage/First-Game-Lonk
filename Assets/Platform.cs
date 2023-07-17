using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform left;

    public Transform right;

    public float moveTime = 3;
    private bool moving;
    // Start is called before the first frame update
    void Start()
    {
        backAndFourth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnCollisionStay2D(Collision2D other)
    {
        creature creature = other.gameObject.GetComponent<creature>();
        if (creature != null)
        {
            // Set the creature as a child of the platform
            creature.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        creature creature = other.gameObject.GetComponent<creature>();
        if (creature != null)
        {
            // Unset the creature as a child of the platform
            creature.transform.SetParent(null);
        }
    }

    void backAndFourth() {
        
        StartCoroutine(backAndFourthRoutine());
        IEnumerator backAndFourthRoutine(){
            while(true){
                float t = 0;
                yield return new WaitForSeconds(1);

                while(t<moveTime){
                    yield return null;
                    t+=Time.deltaTime;
                    transform.position = Vector3.Lerp(left.transform.position,right.transform.position,t/moveTime);
                }

                yield return new WaitForSeconds(1);
                t = 0;

                while(t<moveTime){
                    yield return null;
                    t+=Time.deltaTime;
                    transform.position = Vector3.Lerp(right.transform.position,left.transform.position,t/moveTime);
                }

                yield return null;
                }
            
        }
    }


}
