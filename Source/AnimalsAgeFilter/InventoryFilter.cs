using Verse;

namespace AnimalsAgeFilter
{
    public class SpecialThingFilterWorker_AllowCarrying : SpecialThingFilterWorker
    {

        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }

            return pawn.inventory.innerContainer.Count > 0;
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn && def.race.packAnimal;
        }
    }

    public class SpecialThingFilterWorker_AllowNotCarrying : SpecialThingFilterWorker
    {

        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }

            if (!pawn.def.race.packAnimal)
            {
                return true;
            }
            else
            {
                return pawn.inventory.innerContainer.Count <= 0;
            }
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }
}
