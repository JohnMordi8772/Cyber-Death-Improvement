using UnityEngine;

namespace GoofyGhosts
{
    public class ShopInteractable : MonoBehaviour, IInteractable
    {
        private Collider trigger;
        private Animator anim;

        [SerializeField] private GameObject popup;
        [SerializeField] private GameObject bgmManager;
        [SerializeField] private IntChannelSO waveChannel;

        private GameObject scm;
        private BGMPlayer bgm;
        private SceneLoader scene;

        private void Awake()
        {
            trigger = GetComponent<Collider>();

            anim = popup.GetComponent<Animator>();

            scm = GameObject.Find("SceneManager");
            scene = scm.GetComponent<SceneLoader>();

            bgm = bgmManager.GetComponent<BGMPlayer>();
        }

        private void OnEnable()
        {
            waveChannel.OnEventRaised += OnWaveChange;
        }

        private void OnDisable()
        {
            waveChannel.OnEventRaised -= OnWaveChange;
        }

        private void OnWaveChange(int waveNum)
        {
            if (waveNum == -1)
            {
                trigger.enabled = true;
            }
            else
            {
                trigger.enabled = false;
            }
        }

        public void Interact(IInteractor interactor)
        {
            bgm.StopBGM();
            scene.LoadShopScene();
        }

        public void OnAssigned(IInteractor interactor)
        {
            anim.SetTrigger("interact");
        }

        public void OnUnassigned(IInteractor interactor)
        {
            anim.SetTrigger("back");
        }

    }
}
