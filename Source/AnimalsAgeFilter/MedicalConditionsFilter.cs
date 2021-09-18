using RimWorld;
using System.Linq;
using Verse;

namespace AnimalsAgeFilter
{


    public class SpecialThingFilterWorker_AllowWithTendeableCondition : SpecialThingFilterWorker
    {

        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }

            return pawn.HasTendableHediffNowOrLater();

        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }

    public class SpecialThingFilterWorker_AllowWithoutTendeableCondition : SpecialThingFilterWorker
    {

        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }

            return !pawn.HasTendableHediffNowOrLater();

        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }



}
