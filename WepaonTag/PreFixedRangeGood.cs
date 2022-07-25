using Terraria;
using Terraria.ModLoader;

namespace SkyHell.WepaonTag
{

	public class PreFixedRangeGood : ModPrefix
	{

		public virtual float Power => 1f;

		public override PrefixCategory Category => PrefixCategory.Ranged;

		public override bool CanRoll(Item item)
		{
			return true;
		}

		public override float RollChance(Item item)
		{
			return 1.5f;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
			shootSpeedMult *= 1+0.15f;
			critBonus += 7;
			damageMult *= 1+0.15f;
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
