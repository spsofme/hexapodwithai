using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using System;
using Unity.Mathematics;
using Unity.VisualScripting;

public class MoveToGoalAgent : Agent
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float moveSpeed = 100.0f;

    private readonly int goalNumber = 1;
    private int goalCounter = 0;
    private long attempValue = 0;
    private long successValue = 0;

    private Rigidbody rb;

    //public AttempNumber attempComponent;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        //attempComponent = (AttempNumber) GameObject.Find("BasariSayisi").ConvertTo((new AttempNumber()).GetType());
    }

    public override void OnEpisodeBegin()
    {
        transform.position = new Vector3(1f, 2.33f, 1f);
        goalCounter = 0;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(targetTransform.position);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveRotate = actions.ContinuousActions[0];
        float moveForward = actions.ContinuousActions[1];

        rb.MovePosition(transform.position + moveForward * moveSpeed * Time.deltaTime * transform.forward);
        transform.Rotate(0f, moveRotate * moveSpeed, 0f, Space.Self);

        /*
        //Debug.Log(actions.DiscreteActions[0]);
        //Debug.Log(actions.ContinuousActions[0]);
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];


        transform.position += moveSpeed * Time.deltaTime * new Vector3(moveX, 0, moveZ);
        //transform.rotation = new Quaternion(0f, moveX, 0f, 0f);
        */
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Goal>(out Goal goal))
        {
            //if (! goal.isTriggered)
            //{
            //    SetReward(+5f);
            //    goal.isTriggered = true;
            //    goalCounter++;

            //    if (goalCounter >= goalNumber)
            //    {
            //        successValue++;
            //        EndEpisode();
            //    }
            //}
            SetReward(+5f);
            EndEpisode();
        }
        if (other.TryGetComponent<Wall>(out Wall wall))
        {
            SetReward(-1f);
            EndEpisode();
        }
        attempValue++;

        //attempComponent.text.text = attempValue.ToString();
    }
}
