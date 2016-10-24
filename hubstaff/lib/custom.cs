using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace custom_space
{
    class customClass{
		private connection.connection_class connection = new connection.connection_class();
        public Task<string> custom (string app_token,string auth_token,string start_date, string end_date, Dictionary<string, string> options, String url = "")
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields["Auth-Token"] = auth_token;
            fields["App-token"] = app_token;
			fields["start_date"] = start_date;
			fields["end_date"] = end_date;

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["Auth-Token"] = "header";
            parameters["App-token"] = "header";
			parameters["start_date"] = "";
			parameters["end_date"] = "";

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

            if(!String.IsNullOrEmpty(options["show_tasks"]))
            {
                fields["show_tasks"] = options["show_tasks"];
                parameters["show_tasks"] = "";
            }

            if(!String.IsNullOrEmpty(options["show_notes"]))
            {
                fields["show_notes"] = options["show_notes"];
                parameters["show_notes"] = "";
            }

            if(!String.IsNullOrEmpty(options["show_activity"]))
            {
                fields["show_activity"] = options["show_activity"];
                parameters["show_activity"] = "";
            }

            if(!String.IsNullOrEmpty(options["include_archived"]))
            {
                fields["include_archived"] = options["include_archived"];
                parameters["include_archived"] = "";
            }


            return connection.make_connection(fields, parameters, url, 0);
        }
    }
}