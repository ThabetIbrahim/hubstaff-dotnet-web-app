using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace orgs_space
{
    class orgsClass{
		private connection.connection_class connection = new connection.connection_class();
		public Task<string> get_organizations (string app_token,string auth_token, int offset = 0,String url = "")
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

		public Task<string> find_organization (string app_token,string auth_token,String url = "")
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields["Auth-Token"] = auth_token;
            fields["App-token"] = app_token;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["Auth-Token"] = "header";
            parameters["App-token"] = "header";
            return connection.make_connection(fields, parameters, url, 0);
        }

		public Task<string> find_org_projects (string app_token,string auth_token,int offset,String url = "")
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

		public Task<string> find_org_members (string app_token,string auth_token,int offset,String url = "")
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