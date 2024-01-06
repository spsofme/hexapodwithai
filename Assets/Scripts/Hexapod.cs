using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class Hexapod : Agent
{
    //// Start is called before the first frame update
    //void Start()
    //{
    //    Dictionary<string, float> defaultDegrees = new Dictionary<string, float>{
    //        { "x", 0f },
    //        { "y", 0f },
    //        { "z", 18.388f },
    //    };
    //    GameObject LegRightTop0 = GameObject.Find("FrontRightLeg01");

    //    if (LegRightTop0 != null)
    //    {
    //        Transform transform = LegRightTop0.GetComponent<Transform>();

    //        if (transform != null)
    //        {
    //            //transform.rotation = Quaternion.Euler(0.0F, 0.0F, -45.0F);
    //            //transform.eulerAngles = new Vector3(0f, 0f, 45f);
    //            //transform.Rotate(0f, 0f, 45f);
    //            TransformRotate(transform, defaultDegrees, 0f, 0f, 45f);
    //        }
    //    }
    //}

    public override void OnEpisodeBegin()
    {
        Leg leg1 = new();
        leg1.AddJoint("FrontRightLeg01", Shared.Axis.Z, 0f, 0f, 18.388f);
        leg1.AddJoint("FrontRightLeg02", Shared.Axis.Z, -10.837f, -30.524f, 6.663f);
        leg1.AddJoint("FrontRightLeg03", Shared.Axis.Z, 1.078f, -62.113f, 34.047f);
        leg1.RotateRight();

    }

    //// Update is called once per frame
    //void Update()
    //{
    //}
}
