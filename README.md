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