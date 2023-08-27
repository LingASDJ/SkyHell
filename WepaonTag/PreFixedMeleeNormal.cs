using Terraria;
using Terraria.ModLoader;

namespace SkyHell.WepaonTag
{
	//愚钝 近战T3
	/*
	 +5%伤害
	 -10%大小
	-15%攻速
	 */
	public class PreFixedMeleeNormal : ModPrefix
	{

		public virtual float Power => 1f;

        public override PrefixCategory Category => PrefixCategory.Melee;

        public override bool CanRoll(Item item)
		{
			return true;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
			damageMult *= 1+0.05f * Power;
			scaleMult -= 0.1f * Power;
			useTimeMult += 0.35f * Power;
			knockbackMult *= 0.8f * Power;
		}

		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1f + 0.5f * Power;
		}

		public override void Apply(Item item)
		{
		}
	}
}
