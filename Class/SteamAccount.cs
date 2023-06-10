using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamManager.Class
{
    internal class SteamAccount
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

        public SteamAccount(string steamid, string communityvisibilitystate, string profilestate, string personaname, string lastlogoff, string commentpermission, string profileurl, string avatar, string avatarmedium, string avatarfull, string personastate, string realname, string primaryclanid, string timecreated, string personastateflags, string loccountrycode, string gameid, string gameserverip, string gameextrainfo, string cityid, string locstatecode, string loccityid)
        {
            this.steamid = steamid ?? throw new ArgumentNullException(nameof(steamid));
            this.communityvisibilitystate = communityvisibilitystate ?? throw new ArgumentNullException(nameof(communityvisibilitystate));
            this.profilestate = profilestate ?? throw new ArgumentNullException(nameof(profilestate));
            this.personaname = personaname ?? throw new ArgumentNullException(nameof(personaname));
            this.lastlogoff = lastlogoff ?? throw new ArgumentNullException(nameof(lastlogoff));
            this.commentpermission = commentpermission ?? throw new ArgumentNullException(nameof(commentpermission));
            this.profileurl = profileurl ?? throw new ArgumentNullException(nameof(profileurl));
            this.avatar = avatar ?? throw new ArgumentNullException(nameof(avatar));
            this.avatarmedium = avatarmedium ?? throw new ArgumentNullException(nameof(avatarmedium));
            this.avatarfull = avatarfull ?? throw new ArgumentNullException(nameof(avatarfull));
            this.personastate = personastate ?? throw new ArgumentNullException(nameof(personastate));
            this.realname = realname ?? throw new ArgumentNullException(nameof(realname));
            this.primaryclanid = primaryclanid ?? throw new ArgumentNullException(nameof(primaryclanid));
            this.timecreated = timecreated ?? throw new ArgumentNullException(nameof(timecreated));
            this.personastateflags = personastateflags ?? throw new ArgumentNullException(nameof(personastateflags));
            this.loccountrycode = loccountrycode ?? throw new ArgumentNullException(nameof(loccountrycode));
            this.gameid = gameid ?? throw new ArgumentNullException(nameof(gameid));
            this.gameserverip = gameserverip ?? throw new ArgumentNullException(nameof(gameserverip));
            this.gameextrainfo = gameextrainfo ?? throw new ArgumentNullException(nameof(gameextrainfo));
            this.cityid = cityid ?? throw new ArgumentNullException(nameof(cityid));
            this.locstatecode = locstatecode ?? throw new ArgumentNullException(nameof(locstatecode));
            this.loccityid = loccityid ?? throw new ArgumentNullException(nameof(loccityid));
        }


        //GETTER
        public string getSteamID {  get { return steamid; } }
        public string getCredentials { get { return credentials; } }

        //SETTER
        public void setSteamID(String steamID) { this.steamid = steamID; }
        public void setCredentials(String  credentials) { this.credentials = credentials; }

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
