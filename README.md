# OutSystems Developer Cloud External Logic Connector for AWS Simple Storage Service S3

This external logic connector wraps the offical AWS .NET SDK for S3

## Actions
The library exposes the following actions

### GetObject

Retrieves an object from Amazon S3

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1).
* `getObjectRequest` - GetObject Request Parameters.

**Result**

* `result` - GetObject result structure

### DeleteBucket

Deletes an Amazon S3 bucket

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1).
* `deleteBucketRequest` - DeleteBucket Request Parameters.

### ListBuckets

List Amazon S3 Buckets

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1).

**Result**

* `result` - ListBuckets result structure

### PutBucket

Creates an Amazon S3 bucket

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1).
* `putBucketRequest` - PutBucket Request Parameters.

### ListObjects

List objects in an Amazon S3 Buckets

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1).
* `listObjectsRequest` - ListObjects Request Parameters

**Result**

* `result` - ListObjects result structure

### PutObject

Allows to put a binary or text object to an AWS S3 Bucket including tags and metadata

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1).
* `putObjectRequest` - PutObject request parameters

**Result**

* `result` - PutObject result structure

### DeleteObject

Deletes a single object from an S3 bucket

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1).
* `deleteObjectRequest` - DeleteObject request parameters

**Result**

* `result` - DeleteObject result structure
