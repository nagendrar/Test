using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

public class UploadAndDownloadHandler : MonoBehaviour
{
    IAmazonS3 client;
    const string bucketName = "anuraggadibucket";
    const string awsAccessKey = "AKIAI32HCT3H5PU7RW7Q";
    const string awsSecretKey = "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";

    private void Start()
    {
        client = new AmazonS3Client(awsAccessKey, awsSecretKey, RegionEndpoint.APSouth1);

        string folderPath = "my-folder/sub-folder/";

        PutObjectRequest request = new PutObjectRequest()
        {
            BucketName = bucketName,
            Key = folderPath // <-- in S3 key represents a path  
        };

        PutObjectResponse response = client.PutObject(request);
    }

    //Content Upload Functions
    public void UploadFile()
    {
        FileInfo file = new FileInfo(@"D:\Nagendra\DOCUMENTAION.docx");
        string path = "my-folder/sub-folder/DOCUMENTAION.docx";

        PutObjectRequest request = new PutObjectRequest()
        {
            InputStream = file.OpenRead(),
            BucketName = bucketName,
            Key = path // <-- in S3 key represents a path  
        };

        PutObjectResponse response = client.PutObject(request);
    }

    public void ListAllObjects()
    {
        ListObjectsRequest request = new ListObjectsRequest
        {
            BucketName = bucketName,
            Prefix = "my-folder/sub-folder/"
        };

        ListObjectsResponse response = client.ListObjects(request);
        foreach (S3Object obj in response.S3Objects)
        {
            Debug.Log(obj.Key);
        }
    }

    public void DeleteFilesORFolders()
    {
        string filePath = "my-folder/sub-folder/DOCUMENTAION.docx";
        var deleteFileRequest = new DeleteObjectRequest
        {
            BucketName = bucketName,
            Key = filePath
        };
        DeleteObjectResponse fileDeleteResponse = client.DeleteObject(deleteFileRequest);

        // delete sub-folder  
        string folderPath = "my-folder/sub-folder/";
        var deleteFolderRequest = new DeleteObjectRequest
        {
            BucketName = bucketName,
            Key = folderPath
        };
        DeleteObjectResponse folderDeleteResponse = client.DeleteObject(deleteFolderRequest);
    }


    //Content Download Functions
    public void Download()
    {
        StartCoroutine(DownloadFile());
    }

    IEnumerator DownloadFile()
    {
        var uwr = new UnityWebRequest("https://anuraggadibucket.s3.ap-south-1.amazonaws.com/anurag%2Bresume%2B.pdf", UnityWebRequest.kHttpVerbGET);
        string path = Path.Combine(Application.persistentDataPath, "Anurag.pdf");
        uwr.downloadHandler = new DownloadHandlerFile(path);
        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError || uwr.isHttpError)
            Debug.LogError(uwr.error);
        else
            Debug.Log("File successfully downloaded and saved to " + path);
    }
}
