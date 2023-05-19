using System;
using System.Collections.Generic;

namespace GameCore.Jsons
{
    [Serializable]
    public class TDRoot
    {
        public TDContent Content;
    }
    
    [Serializable]
    public class TDContent
    {
        public TournamentDetails TournamentDetails;
    }
    
    [Serializable]
    public class TournamentDetails
    {
        public TournamentParameters TournamentDefition;
        public List<Participant> Participants;
        public string TournamentID;
        public string ClaimID;
    }
    
    [Serializable]
    public class TournamentParameters
    {
        public string ID;
        public List<int> PrizesGems;
        public List<object> PrizesBonusCash;
        public List<object> PrizesCash;
        public string GameType;
        public int ParticipantsCount;
        public string DisplayName;
        public int EntryFeeCash;
        public int EntryFeeGems;
        public string TournamentType;
    }
    
    [Serializable]
    public class Participant
    {
        public string ParticipantStatus;
        public int ScorePosition;
        public int Score;
        public UserPublicData UserPublicData;
        public int PrizeAmountGems;
        public bool IsYou;
    }
    
    [Serializable]
    public class UserPublicData
    {
        public string DisplayName;
        public AvatarImage AvatarImage;
    }
    
    [Serializable]
    public class AvatarImage
    {
        public string Type;
        public string ID;
    }








    /*[System.Serializable]
    public class TournamentDetails
    {
        public TournamentDetails(TournamentDefinition tournamentDefinition, Participant[] participants, string tournamentID, string claimID)
        {
            TournamentDefinition = tournamentDefinition;
            Participants = participants;
            TournamentID = tournamentID;
            ClaimID = claimID;
        }

        public TournamentDefinition TournamentDefinition;
        public Participant[] Participants;
        public string TournamentID, ClaimID;
    }*/
    
    //[System.Serializable]
    /*public class TournamentDefinition
    {
        public TournamentDefinition(string id, int[] prizeGems, int[] prizesBonusCash, int[] prizesCash, 
            int participantsCount, int entryFeeCash, int entryFeeGems, string gameType, string tournamentType, string displayName)
        {
            ID = id;
            PrizeGems = prizeGems;
            PrizesBonusCash = prizesBonusCash;
            PrizesCash = prizesCash;
            ParticipantsCount = participantsCount;
            EntryFeeCash = entryFeeCash;
            EntryFeeGems = entryFeeGems;
            GameType = gameType;
            TournamentType = tournamentType;
            DisplayName = displayName;
        }

        public string ID;
        public int[] PrizeGems, PrizesBonusCash, PrizesCash;
        public int ParticipantsCount, EntryFeeCash, EntryFeeGems;
        public string GameType, TournamentType, DisplayName;
    }*/

    /*[System.Serializable]
    public class Participant
    {
        public Participant(string participantStatus, int scorePosition, int score, int prizeAmountGems, bool isYou)
        {
            ParticipantStatus = participantStatus;
            ScorePosition = scorePosition;
            Score = score;
            PrizeAmountGems = prizeAmountGems;
            IsYou = isYou;
        }

        public string ParticipantStatus;
        public int ScorePosition, Score, PrizeAmountGems;
        public bool IsYou;
        
    }

    [System.Serializable]
    public class UserPublicData
    {
        public UserPublicData(string displayName, AvatarImage avatarImage)
        {
            DisplayName = displayName;
            this.avatarImage = avatarImage;
        }

        public string DisplayName;
        public AvatarImage avatarImage;
        
        [System.Serializable]
        public class AvatarImage
        {
            public AvatarImage(string type, string id)
            {
                Type = type;
                ID = id;
            }

            public string Type, ID;
        }
    }*/
}