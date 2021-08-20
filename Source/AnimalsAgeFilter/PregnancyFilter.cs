using RimWorld;
using Verse;

namespace AnimalsAgeFilter
{
    public class SpecialThingFilterWorker_AllowPregnant : SpecialThingFilterWorker
    {

        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }

            CompEggLayer compEggLayer = pawn.TryGetComp<CompEggLayer>();
            if (compEggLayer != null)
            {
                // if can LayEgg
                return compEggLayer.FullyFertilized;
            }
            else
            {
                return pawn.health.hediffSet.HasHediff(HediffDefOf.Pregnant);
            }
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }

    public class SpecialThingFilterWorker_AllowNotPregnant : SpecialThingFilterWorker
    {

        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }

            CompEggLayer compEggLayer = pawn.TryGetComp<CompEggLayer>();
            if (compEggLayer != null)
            {
                return !compEggLayer.FullyFertilized;
            }
            else
            {
                return !pawn.health.hediffSet.HasHediff(HediffDefOf.Pregnant);
            }
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }
}
