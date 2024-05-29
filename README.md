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
