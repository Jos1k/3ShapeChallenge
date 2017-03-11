# **3SHAPE CODING CHALLENGE**

### What do you need to run solution from VS
1. Visual Studio (2015/2017)
2. .NET Core

### How to run solution in VS
1. Open solution in Visual Studio
2. Wait for restoring packages
3. Run solution

## Samples of requests
#### ADD NEW USER
```
URL: [POST] http://localhost:61737/api/users
BODY: 
	{
		"email": "ihor.hadzera@gmail.com",
		"name":"ihor",
		"birthday":"25-09-1995"
	}
```
#### GET ALL USERS
```
URL: [GET] http://localhost:61737/api/users
```
#### FIND USER BY CRITERIA
```
URL: [GET] http://localhost:61737/api/users/find?todate=02-09-1993
URL: [GET] http://localhost:61737/api/users/find?id=1acf6762-9890-4257-a6d3-ae2ea5aa540e
URL: [GET] http://localhost:61737/api/users/find?email=ihor.hadzera@gmail.com
```