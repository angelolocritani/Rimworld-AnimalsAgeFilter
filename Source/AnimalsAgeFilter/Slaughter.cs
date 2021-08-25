using RimWorld;
using System.Linq;
using Verse;

namespace AnimalsAgeFilter
{


    public class SpecialThingFilterWorker_AllowShouldBeSlaughtered : SpecialThingFilterWorker
    {

        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }

            return pawn.ShouldBeSlaughtered();
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }

    public class SpecialThingFilterWorker_AllowNotShouldBeSlaughtered : SpecialThingFilterWorker
    {

        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }

            return !pawn.ShouldBeSlaughtered();
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }
}