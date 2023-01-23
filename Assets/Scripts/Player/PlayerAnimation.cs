using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int Respawning = Animator.StringToHash("Respawning");

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