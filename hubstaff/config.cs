using System;
using System.IO;

namespace config
{
    class config_class
    {     
        
        public string root_folder = Directory.GetCurrentDirectory()+"/";
        public config_class()
        {
            if(Path.GetFileName(Directory.GetCurrentDirectory()) != "hubstaff")
            {
                root_folder =  Directory.GetCurrentDirectory()+"/hubstaff/";
            }
        }
        
        public string base_url = "https://api.hubstaff.com/v1/";
        public string auth_url = "auth";
        public string users = "users";
        public string find_user = "users/{0}";
        public string find_user_org = "users/{0}/organizations";
        public string find_user_projects = "users/{0}/projects";
        
        public string orgs = "organizations";
        public string find_org = "organizations/{0}";
        public string find_org_proj = "organizations/{0}/projects";
        public string find_org_members = "organizations/{0}/members";

        public string proj = "projects";
        public string find_proj = "projects/{0}";
        public string find_proj_members = "projects/{0}/members";
        public string activities = "activities";
        public string screenshots = "screenshots";

        public string notes = "notes";
        public string find_note = "notes/{0}";

        public string weekly_team = "weekly/team";
        public string weekly_my = "weekly/my";

        public string custom_date_team = "custom/by_date/team";
        public string custom_date_my = "custom/by_date/my";

        public string custom_member_team = "custom/by_member/team";
        public string custom_member_my = "custom/by_member/my";

        public string custom_project_team = "custom/by_project/team";
        public string custom_project_my = "custom/by_project/my";
    }
}
