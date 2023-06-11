using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace SteamManager.Class
{
    public class SteamAccount
    {
        private string steamid;
        private string communityvisibilitystate;
        private string profilestate;
        private string personaname;
        private string lastlogoff;
        private string commentpermission;
        private string profileurl;
        private string avatar;
        private string avatarmedium;
        private string avatarfull;
        private string personastate;
        private string realname;
        private string primaryclanid;
        private string timecreated;
        private string personastateflags;
        private string loccountrycode;
        private string gameid;
        private string gameserverip;
        private string gameextrainfo;
        private string cityid;
        private string locstatecode;
        private string loccityid;

        public SteamAccount(string steamAPIResponse)
        {
            //VALIDATE AN ASSIGN JTOKEN
            JObject json = JObject.Parse(steamAPIResponse);
            JToken player = json["response"]["players"].FirstOrDefault();

            steamid = player.Value<string>("steamid");
            communityvisibilitystate = player.Value<string>("communityvisibilitystate");
            profilestate = player.Value<string>("profilestate");
            personaname = player.Value<string>("personaname");
            lastlogoff = player.Value<string>("lastlogoff");
            commentpermission = player.Value<string>("commentpermission");
            profileurl = player.Value<string>("profileurl");
            avatar = player.Value<string>("avatar");
            avatarmedium = player.Value<string>("avatarmedium");
            avatarfull = player.Value<string>("avatarfull");
            personastate = player.Value<string>("personastate");
            realname = player.Value<string>("realname");
            primaryclanid = player.Value<string>("primaryclanid");
            timecreated = player.Value<string>("timecreated");
            personastateflags = player.Value<string>("personastateflags");
            loccountrycode = player.Value<string>("loccountrycode");
            gameid = player.Value<string>("gameid");
            gameserverip = player.Value<string>("gameserverip");
            gameextrainfo = player.Value<string>("gameextrainfo");
            cityid = player.Value<string>("cityid");
            locstatecode = player.Value<string>("locstatecode");
            loccityid = player.Value<string>("loccityid");
        }


        //GETTER
        public string getSteamID {  get { return steamid; } }
        public string getCommunityState { get { return communityvisibilitystate; } }
        public string getProfileState { get { return profilestate; } }
        public string getPersonName { get { return personaname; } }
        public string getLastLogoff { get { return lastlogoff; } }
        public string getCommentPermission { get { return commentpermission; } }
        public string getProfileURL { get { return profileurl; } }
        public string getAvatar { get { return avatar; } }
        public string getAvatarMedium { get { return avatarmedium; } }
        public string getAvatarFull { get { return avatarfull; } }
        public string getPersonAsState { get { return personastate; } }
        public string getRealName { get { return realname; } }
        public string getCredentialsPrimaryClanID { get { return primaryclanid; } }
        public string getTimeCreated { get { return timecreated; } }
        public string getPersonaStateFlags { get { return personastateflags; } }
        public string getLocalCountryCode { get { return loccountrycode; } }
        public string getGameID { get { return gameid; } }
        public string getGameServerIP { get { return gameserverip; } }
        public string getGameExtraInfo { get { return gameextrainfo; } }
        public string getCityID { get { return cityid; } }
        public string getLocalStateCode { get { return locstatecode; } }
        public string getLocalCityID { get { return loccityid; } }
        public string[] getSteamInformation()
        {
            return new string[]
            {
                steamid,
                communityvisibilitystate,
                profilestate,
                personaname,
                lastlogoff,
                commentpermission,
                profileurl,
                avatar,
                avatarmedium,
                avatarfull,
                personastate,
                realname,
                primaryclanid,
                timecreated,
                personastateflags,
                loccountrycode,
                gameid,
                gameserverip,
                gameextrainfo,
                cityid,
                locstatecode,
                loccityid
            };
        }

        public string GetStatusAsString()
        {
            switch (personastate)
            {
                case "0":
                    return "Offline";
                case "1":
                    return "Online";
                case "2":
                    return "Busy";
                case "3":
                    return "Away";
                default:
                    return "Unknown Status";
            }
        }


        //EQUAL METHOD
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        //HASHCODE
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //TO STRING
        public override string ToString()
        {
            return base.ToString();
        }
    }

}
