using UnityEngine;

namespace TPS.WeaponSystem.FX
{
	public class WeaponParticleFX : WeaponFX
	{
        [Header("Elements")]
        [SerializeField] protected ParticleSystem[] _particleSystems;



        protected override void OnShot()
		{
			foreach (var p in _particleSystems)
			{
				p.Play();
			}
		}
	}
}