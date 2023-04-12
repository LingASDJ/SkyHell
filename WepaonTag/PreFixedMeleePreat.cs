using Terraria;
using Terraria.ModLoader;

namespace SkyHell.WepaonTag
{
	//神宗 近战T0
	/*
	 +20%伤害
	 +14%速度
	 +12%暴击率
	 +25%击退力
	 +40%大小
	 */
	public class PreFixedMeleePreat : ModPrefix
	{

		public virtual float Power => 1f;

        public override PrefixCategory Category => PrefixCategory.Custom;

        public override float RollChance(Item item)
		{
			return 0.77f;
		}

		public override bool CanRoll(Item item)
		{
			return true;
		}
		
		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
			damageMult *= 1f + 0.20f * Power;
			useTimeMult -= 0.14f * Power;
			knockbackMult *= 1f+ 0.25f * Power;
			scaleMult *= 1f + 0.4f * Power;
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
