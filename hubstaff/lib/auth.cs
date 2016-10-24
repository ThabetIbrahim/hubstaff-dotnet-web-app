using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace auth_space
{
    class authClass
    {
		private connection.connection_class connection = new connection.connection_class();
		public Task<string> gen_auth (string app_token,string email, string password,String url,int type = 0)
        {
            Dictionary<string, string>  fields = new Dictionary<string, string>();
            fields["App-token"] = app_token;
            fields["email"] = email;
            fields["password"] = password;

            Dictionary<string, string>  parameters = new Dictionary<string, string>();
            parameters["App-token"] = "header";
            parameters["email"] = "";
            parameters["password"] = "";

			return connection.make_connection(fields, parameters, url, type);
		}
    }
}
