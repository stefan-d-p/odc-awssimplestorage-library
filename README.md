# OutSystems Developer Cloud External Logic Connector for AWS Simple Storage Service S3

This external logic connector wraps the official AWS .NET SDK for S3

This connector has support for custom S3 endpoints, including OutSystems Developer Cloud Private Gateway. To use functions
with a private gateway set `UseSecureGateway` in the config structure to true.

To use a custom endpoint set `ServiceURL` in the config structure to your custom S3 endpoint.


## Actions
The library exposes the following actions

### GetObject

Retrieves an object from Amazon S3

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `config` - S3 Configuration Details
* `getObjectRequest` - GetObject Request Parameters.

**Result**

* `result` - GetObject result structure

### GetObjectMetadata

Retrieves an object's metadata from Amazon S3, without returning the object itself

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `config` - S3 Configuration Details
* `getObjectMetadataRequest` - GetObjectMetadata Request Parameters.

**Result**

* `result` - GetObjectMetadata result structure

### DeleteBucket

Deletes an Amazon S3 bucket

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `config` - S3 Configuration Details
* `deleteBucketRequest` - DeleteBucket Request Parameters.

### ListBuckets

List Amazon S3 Buckets

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `config` - S3 Configuration Details

**Result**

* `result` - ListBuckets result structure

### PutBucket

Creates an Amazon S3 bucket

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `config` - S3 Configuration Details
* `putBucketRequest` - PutBucket Request Parameters.

### ListObjects

List objects in an Amazon S3 Buckets

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `config` - S3 Configuration Details
* `listObjectsRequest` - ListObjects Request Parameters

**Result**

* `result` - ListObjects result structure

### PutObject

Allows to put a binary or text object to an AWS S3 Bucket including tags and metadata

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `config` - S3 Configuration Details
* `putObjectRequest` - PutObject request parameters

**Result**

* `result` - PutObject result structure

### DeleteObject

Deletes a single object from an S3 bucket

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `config` - S3 Configuration Details
* `deleteObjectRequest` - DeleteObject request parameters

**Result**

* `result` - DeleteObject result structure

### GetPreSignedUrl

Generates a presigned Url for an S3 object

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `config` - S3 Configuration Details
* `getPresignedUrlRequest` - GetPreSignedUrl request parameters

**Result**

* `url` - The generated Url