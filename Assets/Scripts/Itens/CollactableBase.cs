using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Items
{
    public class CollactableBase : MonoBehaviour
    {  
        public VFXType vFXType;
        public ItemType itemType;

        public string compareTag = "Player";
        public ParticleSystem particleSystemCoin;
        public float timeToHide = 3f;
        public GameObject graphicItem;

        public Collider collider;

        [Header("Sounds")]
        public AudioSource audioSource;

        private void Awake() {
            //if (particleSystem != null) particleSystem.transform.SetParent(null);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }

        private void PlaySFX()
        {
            SFXPool.Instance.Play(vFXType);
        }

        protected virtual void Collect()
        {
            PlaySFX();
            if(collider != null) collider.enabled = false;
            if(graphicItem != null) graphicItem.SetActive(false);
            Invoke(nameof(HideObject), timeToHide);
            OnCollect();  
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }

        protected virtual void OnCollect()
        {
            if (particleSystemCoin != null) particleSystemCoin.Play();
            if (audioSource != null) audioSource.Play();

            ItemManager.Instance.AddByType(itemType);
        }
    }
}