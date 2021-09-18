using System.Collections.Generic;
using Verse;
using RimWorld;
using System.Linq;
using System.Text;

namespace AnimalsAgeFilter
{
    static class Functions
    {
        // from Verse.HealthUtility

        public static bool HasTendableHediffNowOrLater(this Pawn pawn)
        {

            HediffSet hs = pawn.health.hediffSet;

            if (hs == null)
            {
                return false;
            }
            else
            {
                foreach (Hediff hediff in hs.hediffs)
                {
                    //adaptation of  Verse.Hediff.TendableNow

                    if (!hediff.def.tendable || hediff.Severity <= 0f || hediff.FullyImmune() || !hediff.Visible || hediff.IsPermanent())
                    {
                        continue;
                    }

                    if (hediff.IsTended())
                    {
                        // does it need to be tended again later?
                        HediffComp_TendDuration hediffComp_TendDuration = hediff.TryGetComp<HediffComp_TendDuration>();
                        if (hediffComp_TendDuration != null)
                        {
                            if (!hediffComp_TendDuration.TProps.TendIsPermanent)
                            {
                                return true;
                            }
                        }

                    }
                    else
                    {
                        if (hs.GetPartHealth(hediff.Part) > 0f)
                        {
                            //part is not destroyed
                            return true;
                        }
                        else
                        {
                            // part is destroyed, let's check if it's "fresh"

                            if (hediff is Hediff_MissingPart hediff_MissingPart)
                            {
                                if (hediff_MissingPart.IsFreshNonSolidExtremity)
                                {

                                    return true;
                                }
                            }

                        }
                    }
                }
                return false;
            }

        }
    }
}



