using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admins.Foundations.Mapper.Helper
{
    public class AzureHelper
    {
        #region Variables
        static string accesskey = "";
        static string containername = "";
        static string accountname = "";
        #endregion

        #region Methods
        public static async Task<bool> AzureUploadBase64(string Folder, string doc64, string Name)
        {
            try
            {
                byte[] blob = Convert.FromBase64String(doc64);
                StorageCredentials creden = new StorageCredentials(accountname, accesskey);
                CloudStorageAccount acc = new CloudStorageAccount(creden, useHttps: true);
                CloudBlobClient client = acc.CreateCloudBlobClient();
                CloudBlobContainer cont = client.GetContainerReference(containername);
                await cont.CreateIfNotExistsAsync();
                await cont.SetPermissionsAsync(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
                CloudBlockBlob cblob = cont.GetBlockBlobReference(Folder + Name);
                await cblob.UploadFromByteArrayAsync(blob, 0, blob.Length);
            }
            catch (Exception ex)
            {

            }
            return true;
        }
        public static async Task<string> GetBlob(string fileName)
        {
            StorageCredentials creden = new StorageCredentials(accountname, accesskey);
            CloudStorageAccount acc = new CloudStorageAccount(creden, useHttps: true);
            CloudBlobClient client = acc.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference(containername);
            // Connect to the blob file
            CloudBlockBlob blob = container.GetBlockBlobReference($"{fileName}");
            // Get the blob file as text
            byte[] byteImage = null;
            string datauri;
            // Retrieve reference to a blob
            CloudBlockBlob blockBlob2 = container.GetBlockBlobReference(fileName);

            using (var memoryStream = new MemoryStream())
            {
                try
                {
                    await blockBlob2.DownloadToStreamAsync(memoryStream);
                    var bytes = memoryStream.ToArray();
                    var b64String = Convert.ToBase64String(bytes);
                    return b64String;

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return "";
        }
        public static async Task<bool> DeleteBlobStorageFile(string fileName)
        {
            var result = false;
            try
            {
                StorageCredentials creden = new StorageCredentials(accountname, accesskey);
                CloudStorageAccount acc = new CloudStorageAccount(creden, useHttps: true);
                CloudBlobClient client = acc.CreateCloudBlobClient();
                CloudBlobContainer container = client.GetContainerReference(containername);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                await blockBlob.DeleteIfExistsAsync();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion

    }
}
