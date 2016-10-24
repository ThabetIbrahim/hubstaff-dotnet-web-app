using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace user_space
{
    class userClass{
		private connection.connection_class connection = new connection.connection_class();
		public Task<string> get_users (string app_token,string auth_token,int organization_memberships,int project_memberships , int offset = 0,String url = "")
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields["Auth-Token"] = auth_token;
            fields["App-token"] = app_token;
            fields["organization_memberships"] = organization_memberships.ToString();
            fields["project_memberships"] = project_memberships.ToString();
            fields["offset"] = offset.ToString();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["Auth-Token"] = "header";
            parameters["App-token"] = "header";
            parameters["organization_memberships"] = "";
            parameters["project_memberships"] = "";
            parameters["offset"] = "";

            return connection.make_connection(fields, parameters, url, 0);
        }

		public Task<string> find_user (string app_token,string auth_token,String url = "")
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields["Auth-Token"] = auth_token;
            fields["App-token"] = app_token;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["Auth-Token"] = "header";
            parameters["App-token"] = "header";
            return connection.make_connection(fields, parameters, url, 0);
        }

		public Task<string> find_user_orgs (string app_token,string auth_token,int offset,String url = "")
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields["Auth-Token"] = auth_token;
            fields["App-token"] = app_token;
            fields["offset"] = offset.ToString();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["Auth-Token"] = "header";
            parameters["App-token"] = "header";
            parameters["offset"] = "";
            return connection.make_connection(fields, parameters, url, 0);
        }

		public Task<string> find_user_projects (string app_token,string auth_token,int offset,String url = "")
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields["Auth-Token"] = auth_token;
            fields["App-token"] = app_token;
            fields["offset"] = offset.ToString();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["Auth-Token"] = "header";
            parameters["App-token"] = "header";
            parameters["offset"] = "";
            return connection.make_connection(fields, parameters, url, 0);
        }
    }
}