using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
namespace Romi.PathTools
{
    public class cammeraMove : MonoBehaviour
    {
        //variable setup
        float sensitivity;
        [SerializeField] float zoom;
        [SerializeField] Transform lookAt;
        [SerializeField] Toggle camType;
        [SerializeField] Slider slider;
        [SerializeField] PathScript path;
        float xAxis = 0;
        float yAxis = 0;
        bool pressed = false;
        float runtimeDistance = 0;
        float speedDirection = 1f;

        private void Start() { sensitivity = slider.value; }

        void Update()
        {
            //checks the toggle button to decide which cammera script to run
            if (camType.isOn) freeCam();
            else followPath();
        }

        void followPath()
        {
            pressed = false;

            //checks input and sets path postion + direction
            if (Input.GetKey("left"))
            {
                runtimeDistance %= path.PathDistance;
                speedDirection = 1f;
                pressed = true;
            }
            if (Input.GetKey("right"))
            {
                runtimeDistance %= path.PathDistance;
                speedDirection = -1f;
                pressed = true;
            }

            //if a button was pressed it will move the cammara to the decided position on the path
            if (pressed)
            {
                runtimeDistance += sensitivity * 30 * speedDirection * Time.deltaTime;
                transform.position = path.GetPositionAtDistance(runtimeDistance);
                transform.LookAt(lookAt.transform);
            }
        }

        void freeCam()
        {
            pressed = false;

            //gets input with some very ugly if statements
            if (Input.GetKey(KeyCode.RightArrow))
            {
                xAxis += 0.01f;
                pressed = true;
            }
            if (Input.GetKey("left"))
            {
                xAxis -= 0.01f;
                pressed = true;
            }
            if (Input.GetKey("up"))
            {
                yAxis += 0.01f;
                pressed = true;
            }
            if (Input.GetKey("down"))
            {
                yAxis -= 0.01f;
                pressed = true;
            }

            //checks if max height has been reached and remove movement if so
            if (transform.position.y > 10 + (zoom / 3))
            {
                yAxis = -0.1f;
                pressed = true;
            }
            if (transform.position.y < 0)
            {
                yAxis = 0.1f;
                pressed = true;
            }
            if (!pressed)
            {
                xAxis = 0;
                yAxis = 0;
            }

            //rotates cammera around center based on the input
            transform.Translate(new Vector3(xAxis * sensitivity, 0, 0), Space.Self);
            transform.Translate(new Vector3(0, yAxis * sensitivity, 0), Space.Self);
            transform.LookAt(lookAt.transform);
            float dis = Vector3.Distance(transform.position, lookAt.position);

            //keeps cammera a set distance from the lookAt point
            if (dis > 11 + zoom) transform.Translate(Vector3.forward * dis * sensitivity * Time.deltaTime / 2);
            if (dis < 9 + zoom) transform.Translate(-Vector3.forward * dis * sensitivity * Time.deltaTime / 2);
        }

        public void sensChanged() { sensitivity = slider.value; }
    }
}