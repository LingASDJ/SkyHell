using Terraria;
using Terraria.ModLoader;

namespace SkyHell.WepaonTag
{

	public class PreFixedRangePreat : ModPrefix
	{

		public virtual float Power => 1f;

		public override PrefixCategory Category => PrefixCategory.Ranged;

		public override bool CanRoll(Item item)
		{
			return true;
		}

		public override float RollChance(Item item)
		{
			return 0.53f;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
			shootSpeedMult *= 1 + 0.35f;
			critBonus += 18;
			damageMult *= 1 + 0.25f;
			knockbackMult *= 1 + 0.50f;
			useTimeMult *= 0.6f;
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
