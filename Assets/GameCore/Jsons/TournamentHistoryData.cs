using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace GameCore.Jsons
{
    [Serializable]
    public class TournamentHistoryData
    {
        public THContent Content;
    }
    
    [Serializable]
    public class THContent
    {
        public List<TournamentGeneralInfo> tournaments;
    }

    [Serializable]
    public class TournamentGeneralInfo
    {
        public string ID;
        public long CreationTimestamp;
        public int SubmittedScoresCount;
        public int ParticipantsCount;
        public TournamentDefinition TournamentDefinition;
        public int? PrizeAmountCash;
        public string ClaimID;
        public int? PrizeAmountGems;
    }

    [Serializable]
    public class TournamentDefinition
    {
        public string DisplayName;
        public int ParticipantsCount;
    }
}