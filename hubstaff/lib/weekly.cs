using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace weekly_space
{
    class weeklyClass{
		private connection.connection_class connection = new connection.connection_class();
		public Task<string> weekly_team (string app_token,string auth_token, Dictionary<string, string> options,String url = "")
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields["Auth-Token"] = auth_token;
            fields["App-token"] = app_token;

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["Auth-Token"] = "header";
            parameters["App-token"] = "header";

            if(!String.IsNullOrEmpty(options["organizations"]))
            {
                fields["organizations"] = options["organizations"];
                parameters["organizations"] = "";
            }
            if(!String.IsNullOrEmpty(options["projects"]))
            {
                fields["projects"] = options["projects"];
                parameters["projects"] = "";
            }
            if(!String.IsNullOrEmpty(options["users"]))
            {
                fields["users"] = options["users"];
                parameters["users"] = "";
            }

            if(!String.IsNullOrEmpty(options["date"]))
            {
                fields["date"] = options["date"];
                parameters["date"] = "";
            }


            return connection.make_connection(fields, parameters, url, 0);
        }
		public Task<string> weekly_my (string app_token,string auth_token, Dictionary<string, string> options,String url = "")
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields["Auth-Token"] = auth_token;
            fields["App-token"] = app_token;

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["Auth-Token"] = "header";
            parameters["App-token"] = "header";

            if(String.IsNullOrEmpty(options["organizations"]))
            {
                fields["organizations"] = options["organizations"];
                parameters["organizations"] = "";
            }
            if(String.IsNullOrEmpty(options["projects"]))
            {
                fields["projects"] = options["projects"];
                parameters["projects"] = "";
            }
            if(String.IsNullOrEmpty(options["users"]))
            {
                fields["users"] = options["users"];
                parameters["users"] = "";
            }

            if(String.IsNullOrEmpty(options["date"]))
            {
                fields["date"] = options["date"];
                parameters["date"] = "";
            }


            return connection.make_connection(fields, parameters, url, 0);
        }
    }
}