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
                        if (hediff.Part == null || hs.GetPartHealth(hediff.Part) > 0f)
                        {
                            //hediff is applied to whole body (part = null) or part is not destroyed
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

        public static bool HasGatherableBodyResourceReadyToBeHarvested(this Pawn pawn)
        {
            CompHasGatherableBodyResource compHasGatherableBodyResource = pawn.TryGetComp<CompHasGatherableBodyResource>();
            if (compHasGatherableBodyResource != null)
            {
                return compHasGatherableBodyResource.ActiveAndFull;
            }
            else
            {
                return false;
            }

        }


        public static bool HasOnlyTendedInjuries(this Pawn pawn)
        {
            HediffSet hs = pawn.health.hediffSet;

            List<Hediff> hediff_injuries = hs.hediffs.FindAll(h => h is Hediff_Injury && !(h as Hediff_Injury).IsPermanent()); //not permanent injuries only

            if (hediff_injuries.Count == 0) return false; // there are no not permanent injuries, return immediately
            {
                return hediff_injuries.All(h => ((Hediff_Injury)h).IsTended() && ((Hediff_Injury)h).Severity > 0f);
            }
        }


        public static bool HasPermanentInjuries(this Pawn pawn)
        {
            HediffSet hs = pawn.health.hediffSet;

            List<Hediff> hediff_injuries = hs.hediffs.FindAll(h => h is Hediff_Injury && (h as Hediff_Injury).IsPermanent()); // permanent injuries only

            return (hediff_injuries.Count > 0);
        }

    }
}

