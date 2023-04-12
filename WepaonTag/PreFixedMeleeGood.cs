using Terraria;
using Terraria.ModLoader;

namespace SkyHell.WepaonTag
{
	//锐利 近战T2
	/*
	 +10%伤害
	 -5%大小
	+12%暴击率
	+10%速度
	 */
	public class PreFixedMeleeGood : ModPrefix
	{

		public virtual float Power => 1f;
        public override PrefixCategory Category => PrefixCategory.Custom;

        public override float RollChance(Item item)
		{
			return 1.77f;
		}

		public override bool CanRoll(Item item)
		{
			return true;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
			damageMult *= 1f + 0.10f * Power;
			useTimeMult -= 0.10f * Power;
			scaleMult -= 0.05f * Power;
			critBonus += 12;
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
