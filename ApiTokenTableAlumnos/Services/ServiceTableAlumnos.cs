using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTokenTableAlumnos.Services
{
    public class ServiceTableAlumnos
    {
        private CloudTable tablaalumnos;

        public ServiceTableAlumnos(string keys)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(keys);
            CloudTableClient client = account.CreateCloudTableClient();
            this.tablaalumnos = client.GetTableReference("tablaalumnos");
        }

        public string GetKeySas(string curso)
        {
            SharedAccessTablePolicy policy = new SharedAccessTablePolicy
            {
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(30),
                Permissions = SharedAccessTablePermissions.Query | SharedAccessTablePermissions.Delete
            };
            string token = this.tablaalumnos.GetSharedAccessSignature(policy, null, curso, null, curso, null);
            return token;
        }
    }
}
