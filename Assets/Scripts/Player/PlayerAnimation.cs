using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private static readonly int Respawning = Animator.StringToHash("Respawning");
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void StartRespawnAnimation()
        {
            animator.SetBool(Respawning, true);
        }

        public void StopRespawnAnimation()
        {
            animator.SetBool(Respawning, false);
        }
    }
}