# 3Shape Coding Challenge

#What do you need to run solution from VS
1. Visual Studio (2015/2017)
2. .NET Core

#How to run solution in VS
1. Open solution in Visual Studio
2. Wait for restoring packages
3. Run solution

#Available routes
* [GET] http://localhost:61737/api/users - to get list of all users
* [POST] http://localhost:61737/api/users - to add new User (Email, Id, Birthday fields)
* [GET] http://localhost:61737/api/users/find? - to find in request params by [id|email|todate]

#Samples of requests
* ADD NEW USER - 
	URL - [POST] http://localhost:61737/api/users
	BODT - 
		{
			"email": "ihor.hadzera@gmail.com",
			"name":"ihor",
			"birthday":"09/25/1995"
		}
* GET ALL USERS - 
	URL - [GET] http://localhost:61737/api/users
* FIND USER BY CRITERIA -
	URL - [GET] http://localhost:61737/api/users/find?todate=02-09-1993
	URL - [GET] http://localhost:61737/api/users/find?id=1acf6762-9890-4257-a6d3-ae2ea5aa540e
	URL - [GET] http://localhost:61737/api/users/find?email=ihor.hadzera@gmail.com