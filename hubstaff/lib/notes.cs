using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace notes_space
{
    class notesClass{
		private connection.connection_class connection = new connection.connection_class();
		public Task<string> get_notes (string app_token,string auth_token,string starttime, string stoptime, Dictionary<string, string> options, int offset = 0,String url = "")
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields["Auth-Token"] = auth_token;
            fields["App-token"] = app_token;
			fields["start_time"] = starttime;
			fields["stop_time"] = stoptime;

            fields["offset"] = offset.ToString();

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["Auth-Token"] = "header";
            parameters["App-token"] = "header";
			parameters["start_time"] = "";
			parameters["stop_time"] = "";
            parameters["offset"] = "";

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


            return connection.make_connection(fields, parameters, url, 0);
        }
        public Task<string> find_note (string app_token,string auth_token,String url = "")
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields["Auth-Token"] = auth_token;
            fields["App-token"] = app_token;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["Auth-Token"] = "header";
            parameters["App-token"] = "header";
            return connection.make_connection(fields, parameters, url, 0);
        }

    }
}