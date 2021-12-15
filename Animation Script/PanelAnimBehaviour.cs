
using UnityEngine;



public class PanelAnimBehaviour : StateMachineBehaviour
{
    public float SceneTransitionSpeed;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        layerIndex = 0;
        stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.Panel_init"))
        {
            //Debug.Log("Base Layer.Panel_init");
        }
       
       
        animator.speed = SceneTransitionSpeed;

    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.Panel_GameOver"))
        {
            animator.speed = SceneTransitionSpeed * 1.5f;
        }
        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.Panel_Restart"))
        {
            animator.speed = SceneTransitionSpeed * 0.5f;

        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.Panel_Restart"))
        {
            //Debug.Log("Base Layer.Panel_Restart Exit");

        }
    }





}
